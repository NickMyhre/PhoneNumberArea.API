using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneNumberArea.API.Data;

namespace PhoneNumberArea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaCodesController : ControllerBase
    {
        private readonly PhoneNumberAreaDbContext _context;

        public AreaCodesController(PhoneNumberAreaDbContext context)
        {
            _context = context;
        }

        // GET: api/AreaCodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AreaCode>>> GetAreaCodes()
        {
            return await _context.AreaCodes.ToListAsync();
        }

        // GET: api/AreaCodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AreaCode>> GetAreaCode(int id)
        {
            var areaCode = await _context.AreaCodes.FindAsync(id);

            if (areaCode == null)
            {
                return NotFound();
            }

            return areaCode;
        }

        // PUT: api/AreaCodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAreaCode(int id, AreaCode areaCode)
        {
            if (id != areaCode.Id)
            {
                return BadRequest();
            }

            _context.Entry(areaCode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaCodeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AreaCodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AreaCode>> PostAreaCode(AreaCode areaCode)
        {
            _context.AreaCodes.Add(areaCode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAreaCode", new { id = areaCode.Id }, areaCode);
        }

        // DELETE: api/AreaCodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAreaCode(int id)
        {
            var areaCode = await _context.AreaCodes.FindAsync(id);
            if (areaCode == null)
            {
                return NotFound();
            }

            _context.AreaCodes.Remove(areaCode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AreaCodeExists(int id)
        {
            return _context.AreaCodes.Any(e => e.Id == id);
        }
    }
}
