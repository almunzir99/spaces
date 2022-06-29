namespace apiplate.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public int TranslationId { get; set; }
        public Translation Translation { get; set; }
    }
}