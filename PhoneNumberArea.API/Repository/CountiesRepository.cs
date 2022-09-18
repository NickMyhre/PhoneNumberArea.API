using AutoMapper;
using PhoneNumberArea.API.Contracts;
using PhoneNumberArea.API.Data;

namespace PhoneNumberArea.API.Repository
{
    public class CountiesRepository : GenericRepository<County>, ICountiesRepository
    {
        private readonly PhoneNumberAreaDbContext _context;

        public CountiesRepository(PhoneNumberAreaDbContext context, IMapper mapper) : base(context, mapper)
        {
            this._context = context;
        }
    }
}
