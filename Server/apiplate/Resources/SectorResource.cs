namespace apiplate.Resources
{
    public class SectorResource : BaseResource
    {
        public int TitleId { get; set; }
        public TranslationResource Title { get; set; }
        
        public int DescriptionId { get; set; }
        public TranslationResource Description { get; set; }
        public int IconId { get; set; }
        public ImageResource Icon { get; set; }
        public int ImageId { get; set; }
        public ImageResource Image { get; set; }
    }
}