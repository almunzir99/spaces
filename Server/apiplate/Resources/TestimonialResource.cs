namespace apiplate.Resources
{
    public class TestimonialResource : BaseResource
    {
        public int ContentId { get; set; }
        public TranslationResource Content { get; set; }
        public int  AuthorId { get; set; }
        public TranslationResource Author { get; set; }
        public int JobId { get; set; }
        public TranslationResource Job { get; set; }
         public int ImageId { get; set; }
        public ImageResource Image { get; set; }
    }
}