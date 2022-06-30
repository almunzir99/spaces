namespace apiplate.Resources
{
    public class ProjectResource : ArticleResource
    {
        public int SectorId { get; set; }
        public SectorResource Sector { get; set; }
        public int RegionId { get; set; }
        public RegionResource Region { get; set; }
    }
}