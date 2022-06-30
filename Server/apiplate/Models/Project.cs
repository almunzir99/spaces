namespace apiplate.Models
{
    public class Project : ArticleBase
    {
        public int SectorId { get; set; }
        public Sector Sector { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
    }
}