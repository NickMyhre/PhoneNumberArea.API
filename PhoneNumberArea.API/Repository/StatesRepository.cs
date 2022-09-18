using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PhoneNumberArea.API.Contracts;
using PhoneNumberArea.API.Data;
using PhoneNumberArea.API.Models.AreaCode;
using PhoneNumberArea.API.Models.State;

namespace PhoneNumberArea.API.Repository
{
    public class StatesRepository : GenericRepository<State>, IStatesRepository
    {
        private readonly PhoneNumberAreaDbContext _context;
        private readonly IMapper _mapper;

        public StatesRepository(PhoneNumberAreaDbContext context, IMapper mapper) : base(context, mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<GetStateDto> GetDetails(int id)
        {
            var state = await _context.States.Include(q => q.AreaCodes)
                .ProjectTo<GetStateDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (state == null)
            {
                return null;
            }
            return state;
        }
    }
}
