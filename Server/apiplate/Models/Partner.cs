namespace apiplate.Models
{
    public class Partner : BaseModel
    {
        public int NameId { get; set; }
        public Translation Name { get; set; }
        public int LogoId { get; set; }
        public Image Logo { get; set; }
        public string Url { get; set; }
    }
}