using System.ComponentModel.DataAnnotations;

namespace PhoneNumberArea.API.Models.AreaCode
{
    public abstract class BaseAreaCodeDto
    {
        [Required]
        [Range(100, 999)]
        public int Code { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int StateId { get; set; }
    }

}
