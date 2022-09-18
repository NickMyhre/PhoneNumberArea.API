using System.ComponentModel.DataAnnotations;

namespace PhoneNumberArea.API.Models.County
{
    public abstract class BaseCountyDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int AreaCodeId { get; set; }

    }
}
