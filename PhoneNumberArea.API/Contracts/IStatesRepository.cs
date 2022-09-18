using PhoneNumberArea.API.Data;
using PhoneNumberArea.API.Models.State;

namespace PhoneNumberArea.API.Contracts
{
    public interface IStatesRepository : IGenericRepository<State>
    {
        Task<GetStateDto> GetDetails(int id);
    }
}
