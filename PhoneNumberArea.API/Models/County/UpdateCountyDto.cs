using System.ComponentModel.DataAnnotations;

namespace PhoneNumberArea.API.Models.County
{
    public class UpdateCountyDto : BaseCountyDto
    {
        [Required]
        public int Id { get; set; }    
    }
}
