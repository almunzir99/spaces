namespace apiplate.Resources
{
    public class PartnerResource : BaseResource
    {
        public int NameId { get; set; }
        public TranslationResource Name { get; set; }
        public int LogoId { get; set; }
        public ImageResource Logo { get; set; }
        public string Url { get; set; }
    }
}