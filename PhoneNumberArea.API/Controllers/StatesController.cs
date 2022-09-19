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
using PhoneNumberArea.API.Models.State;

namespace PhoneNumberArea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IStatesRepository _statesRepository;
        private readonly IMapper _mapper;

        public StatesController(IStatesRepository statesRepository, IMapper mapper)
        {
            this._statesRepository = statesRepository;
            this._mapper = mapper;
        }

        // GET: api/States
        [HttpGet]
        public async Task<ActionResult<List<StateDto>>> GetStates()
        {
            var states = await _statesRepository.GetAllAsync();
            var result = _mapper.Map<List<StateDto>>(states);
            return Ok(result);
        }
        
        // GET: api/States/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetStateDto>> GetState(int id)
        {
            var state = await _statesRepository.GetDetails(id);

            if (state == null)
            {
                return NotFound();
            }

            var stateDto = _mapper.Map<GetStateDto>(state);

            return Ok(stateDto);
        }
        
        // PUT: api/States/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutState(int id, UpdateStateDto updateStateDto)
        {
            if (id != updateStateDto.Id)
            {
                return BadRequest();
            }

            var state = _mapper.Map<State>(updateStateDto);

            try
            {
                await _statesRepository.UpdateAsync(state);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _statesRepository.Exists(updateStateDto.Id))
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
        
        // POST: api/States
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StateDto>> PostState(CreateStateDto createStateDto)
        {

            var state = _mapper.Map<State>(createStateDto);
            await _statesRepository.AddAsync(state);

            return CreatedAtAction("GetState", new { id = state.Id }, _mapper.Map<StateDto>(state));
        }
        
        // DELETE: api/States/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteState(int id)
        {
            var state = await _statesRepository.GetAsync(id);
            if (state == null)
            {
                return NotFound();
            }

            await _statesRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
