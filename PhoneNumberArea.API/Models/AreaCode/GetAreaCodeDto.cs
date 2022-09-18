using PhoneNumberArea.API.Models.County;

namespace PhoneNumberArea.API.Models.AreaCode
{
    public class GetAreaCodeDto : BaseAreaCodeDto
    {
        public int Id { get; set; }
        public List<GetCountyDto> Counties { get; set; }
    }

}
