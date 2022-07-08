namespace apiplate.Models
{
    public class Media : BaseModel{
        public Image Thumbnail { get; set; }
        public string Url { get; set; }
        public string MediaType { get; set; }
        public bool? MainVideo { get; set; }
    }
}