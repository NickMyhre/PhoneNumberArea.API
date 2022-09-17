﻿using System;
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
    public class CountiesController : ControllerBase
    {
        private readonly PhoneNumberAreaDbContext _context;

        public CountiesController(PhoneNumberAreaDbContext context)
        {
            _context = context;
        }

        // GET: api/Counties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<County>>> GetCounties()
        {
            return await _context.Counties.ToListAsync();
        }

        // GET: api/Counties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<County>> GetCounty(int id)
        {
            var county = await _context.Counties.FindAsync(id);

            if (county == null)
            {
                return NotFound();
            }

            return county;
        }

        // PUT: api/Counties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCounty(int id, County county)
        {
            if (id != county.Id)
            {
                return BadRequest();
            }

            _context.Entry(county).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountyExists(id))
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

        // POST: api/Counties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<County>> PostCounty(County county)
        {
            _context.Counties.Add(county);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCounty", new { id = county.Id }, county);
        }

        // DELETE: api/Counties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCounty(int id)
        {
            var county = await _context.Counties.FindAsync(id);
            if (county == null)
            {
                return NotFound();
            }

            _context.Counties.Remove(county);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountyExists(int id)
        {
            return _context.Counties.Any(e => e.Id == id);
        }
    }
}
