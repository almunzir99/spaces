namespace apiplate.Resources
{
    public class TagResource
    {
        public int Id { get; set; }
        public int TranslationId { get; set; }
        public TranslationResource Translation { get; set; }
    }
}