namespace apiplate.Resources.Requests
{
    public class ProjectRequestResource : ArticleRequestResource
    {
        public int SectorId { get; set; }
        public int RegionId { get; set; }
    }
}