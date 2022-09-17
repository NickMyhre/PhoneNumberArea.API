using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneNumberArea.API.Data
{
    public class County
    {
        public int Id { get; set; }
        public string Name { get; set; }


        [ForeignKey(nameof(AreaCodeId))]
        public int AreaCodeId { get; set; }
        public AreaCode AreaCode { get; set; }
    }
}
