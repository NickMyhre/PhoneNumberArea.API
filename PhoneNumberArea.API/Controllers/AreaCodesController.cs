using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneNumberArea.API.Contracts;
using PhoneNumberArea.API.Data;
using PhoneNumberArea.API.Models.AreaCode;

namespace PhoneNumberArea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaCodesController : ControllerBase
    {
        private readonly IAreaCodesRepository _areaCodesRepository;
        private readonly IMapper _mapper;

        public AreaCodesController(IAreaCodesRepository areaCodesRepository, IMapper mapper)
        {
            this._areaCodesRepository = areaCodesRepository;
            this._mapper = mapper;
        }

        // GET: api/AreaCodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AreaCodeDto>>> GetAreaCodes()
        {
            var areaCodes = await _areaCodesRepository.GetAllAsync();
            var areaCodeDtos = _mapper.Map<List<AreaCodeDto>>(areaCodes);

            return Ok(areaCodeDtos);
        }

        // GET: api/AreaCodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetAreaCodeDto>> GetAreaCode(int id)
        {
            var areaCode = await _areaCodesRepository.GetDetails(id);

            if (areaCode == null)
            {
                return NotFound();
            }

            var areaCodeDto = _mapper.Map<GetAreaCodeDto>(areaCode);

            return Ok(areaCodeDto);
        }

        // PUT: api/AreaCodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAreaCode(int id, UpdateAreaCodeDto updateAreaCodeDto)
        {
            if (id != updateAreaCodeDto.Id)
            {
                return BadRequest();
            }

            var areaCode = await _areaCodesRepository.GetAsync(id);

            _mapper.Map(updateAreaCodeDto, areaCode);

            try
            {
                await _areaCodesRepository.UpdateAsync(areaCode);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _areaCodesRepository.Exists(id))
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
        public async Task<ActionResult<AreaCode>> PostAreaCode(CreateAreaCodeDto createAreaCodeDto)
        {
            var areaCode = _mapper.Map<AreaCode>(createAreaCodeDto);
            await _areaCodesRepository.AddAsync(areaCode);

            return CreatedAtAction("GetAreaCode", new { id = areaCode.Id }, areaCode);
        }

        // DELETE: api/AreaCodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAreaCode(int id)
        {
            var areaCode = await _areaCodesRepository.GetAsync(id);
            if (areaCode == null)
            {
                return NotFound();
            }

            await _areaCodesRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
