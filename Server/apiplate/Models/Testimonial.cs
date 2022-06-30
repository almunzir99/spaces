namespace apiplate.Models
{
    public class Testimonial : BaseModel
    {
        public int ContentId { get; set; }
        public Translation Content { get; set; }
        public int  AuthorId { get; set; }
        public Translation Author { get; set; }
        public int JobId { get; set; }
        public Translation Job { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}