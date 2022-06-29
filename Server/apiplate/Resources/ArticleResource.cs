using System.Collections.Generic;

namespace apiplate.Resources
{
    public class ArticleResource : BaseResource
    {
        public TranslationResource Title { get; set; } = new TranslationResource();
        public TranslationResource Subtitle { get; set; } = new TranslationResource();
        public TranslationResource Content { get; set; } = new TranslationResource();
        public ImageResource Image { get; set; }
        public List<TagResource> Tags { get; set; } = new List<TagResource>();
        public int AuthorId { get; set; }
        public AdminResource Author { get; set; }
        public List<CommentResource> Comments { get; set; } = new List<CommentResource>();
    }
}