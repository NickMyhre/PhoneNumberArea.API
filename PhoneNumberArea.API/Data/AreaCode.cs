using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneNumberArea.API.Data
{
    public class AreaCode
    {
        public int Id { get; set; }
        public int Code { get; set; }

        [ForeignKey(nameof(StateId))]
        public int StateId { get; set; }
        public State State { get; set; }
        public virtual IList<County> Counties { get; set; }
    }
}
