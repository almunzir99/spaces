namespace apiplate.Resources
{
    public class SliderResource : BaseResource
    {
        
        public TranslationResource Title { get; set; }
        public TranslationResource Subtitle { get; set; }
        public TranslationResource Description { get; set; }
        public int ImageId { get; set; }
        public ImageResource Image { get; set; }
        public string Url { get; set; }
    }
}