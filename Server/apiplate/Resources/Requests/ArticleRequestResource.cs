using System.Collections.Generic;

namespace apiplate.Resources.Requests
{
    public class ArticleRequestResource
    {
        public TranslationResource Title { get; set; } = new TranslationResource();
        public TranslationResource Subtitle { get; set; } = new TranslationResource();
        public TranslationResource Content { get; set; } = new TranslationResource();
        public ImageResource Image { get; set; }
        public List<TagResource> Tags { get; set; } = new List<TagResource>();
        public int AuthorId { get; set; }
    }
}