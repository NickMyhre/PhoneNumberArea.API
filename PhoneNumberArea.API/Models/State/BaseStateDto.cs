using System.ComponentModel.DataAnnotations;

namespace PhoneNumberArea.API.Models.State
{
    public abstract class BaseStateDto
    {
        [Required]
        public string Name { get; set; }

        public string Abbreviation { get; set; }
    }
}
