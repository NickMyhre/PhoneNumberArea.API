namespace PhoneNumberArea.API.Data
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public virtual IList<AreaCode> AreaCodes { get; set; }
    }
}
