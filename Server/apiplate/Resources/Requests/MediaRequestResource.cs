namespace apiplate.Resources.Requests
{
    public class MediaRequestResource{
        public ImageResource Thumbnail { get; set; }
        public string Url { get; set; }
        public string MediaType { get; set; }
        public bool? MainVideo { get; set; }

    }
}