using PhoneNumberArea.API.Data;
using PhoneNumberArea.API.Models.AreaCode;

namespace PhoneNumberArea.API.Contracts
{
    public interface IAreaCodesRepository : IGenericRepository<AreaCode>
    {
        Task<GetAreaCodeDto> GetDetails(int id);
    }
}
