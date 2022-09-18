using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PhoneNumberArea.API.Contracts;
using PhoneNumberArea.API.Data;
using PhoneNumberArea.API.Models.AreaCode;

namespace PhoneNumberArea.API.Repository
{
    public class AreaCodesRepository : GenericRepository<AreaCode>, IAreaCodesRepository
    {
        private readonly PhoneNumberAreaDbContext _context;
        private readonly IMapper _mapper;

        public AreaCodesRepository(PhoneNumberAreaDbContext context, IMapper mapper) : base(context, mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<GetAreaCodeDto> GetDetails(int id)
        {
            var areaCode = await _context.AreaCodes.Include(q => q.Counties)
                .ProjectTo<GetAreaCodeDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (areaCode == null)
            {
                return null;
            }
            return areaCode;

        }
    }
}
