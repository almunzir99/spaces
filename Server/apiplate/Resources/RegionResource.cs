namespace apiplate.Resources
{
    public class RegionResource : BaseResource
    {
        public string Code { get; set; }
        public TranslationResource Title { get; set; }
        public TranslationResource Description { get; set; }
        public ImageResource Image { get; set; }

    }
}