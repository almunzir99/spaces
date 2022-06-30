namespace apiplate.Resources.Requests
{
    public class TeamRequestResource
    {
        public TranslationResource Name { get; set; }
        public TranslationResource Position { get; set; }
        public ImageResource Image { get; set; }
        public int Priority { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string LinkedIn { get; set; }
        public string Instgram { get; set; }
    }
}