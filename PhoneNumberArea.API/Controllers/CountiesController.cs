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
using PhoneNumberArea.API.Models.County;

namespace PhoneNumberArea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountiesController : ControllerBase
    {
        private readonly ICountiesRepository _countiesRepository;
        private readonly IMapper _mapper;

        public CountiesController(ICountiesRepository countiesRepository, IMapper mapper)
        {
            this._countiesRepository = countiesRepository;
            this._mapper = mapper;
        }

        // GET: api/Counties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountyDto>>> GetCounties()
        {
            var counties = await _countiesRepository.GetAllAsync();
            var countyDtos = _mapper.Map<List<GetCountyDto>>(counties);
            return Ok(countyDtos);
        }

        // GET: api/Counties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCountyDto>> GetCounty(int id)
        {
            var county = await _countiesRepository.GetAsync(id);

            if (county == null)
            {
                return NotFound();
            }

            var countyDto = _mapper.Map<GetCountyDto>(county);

            return Ok(countyDto);
        }

        // PUT: api/Counties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCounty(int id, UpdateCountyDto updateCountyDto)
        {
            if (id != updateCountyDto.Id)
            {
                return BadRequest();
            }

            var county = await _countiesRepository.GetAsync(id);

            _mapper.Map(updateCountyDto, county);

            try
            {
                await _countiesRepository.UpdateAsync(county);  
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _countiesRepository.Exists(id))
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
        public async Task<ActionResult<County>> PostCounty(CreateCountyDto createCountyDto)
        {
            var county = _mapper.Map<County>(createCountyDto);

            await _countiesRepository.AddAsync(county);

            return CreatedAtAction("GetCounty", new { id = county.Id }, county);
        }

        // DELETE: api/Counties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCounty(int id)
        {
            var county = await _countiesRepository.GetAsync(id);
            if (county == null)
            {
                return NotFound();
            }

            await _countiesRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
