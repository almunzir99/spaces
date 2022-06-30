namespace apiplate.Models
{
    public class Slider : BaseModel
    {
        
        public int TitleId { get; set; }
        public Translation Title { get; set; }
         public int SubtitleId { get; set; }
        public Translation Subtitle { get; set; }
         public int DescriptionId { get; set; }
        public Translation Description { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
        public string Url { get; set; }
    }
}