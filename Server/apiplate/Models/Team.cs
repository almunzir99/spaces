namespace apiplate.Models
{
    public class Team : BaseModel
    {
        public int NameId { get; set; }
        public Translation Name { get; set; }
        public int PositionId { get; set; }
        public Translation Position { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
        public int Priority { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string LinkedIn { get; set; }
        public string Instgram { get; set; }



    }
}