namespace apiplate.Models
{
    public class Region : BaseModel
    {
        public string Code { get; set; }
        public int TitleId { get; set; }
        public Translation Title { get; set; }
         public int DescriptionId { get; set; }
        public Translation Description { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}