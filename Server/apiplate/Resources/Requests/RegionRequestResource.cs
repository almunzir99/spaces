namespace apiplate.Resources.Requests
{
    public class RegionRequestResource{
        public string Code { get; set; }
        public TranslationResource Title { get; set; }
        public TranslationResource Description { get; set; }
        public ImageResource Image { get; set; }
    }
}