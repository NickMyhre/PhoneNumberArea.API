using PhoneNumberArea.API.Models.AreaCode;

namespace PhoneNumberArea.API.Models.State
{
    public class GetStateDto : BaseStateDto
    {
        public int Id { get; set; }
        public List<AreaCodeDto> AreaCodes { get; set; }
    }
}
