using System.Collections.Generic;

namespace apiplate.Models
{
    public class ArticleBase : BaseModel
    {
        public int TitleId { get; set; }
        public Translation Title { get; set; }
        public int SubtitleId { get; set; }
        public Translation Subtitle { get; set; }
        public int ContentId { get; set; }
        public Translation Content { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public int AuthorId { get; set; }
        public Admin Author { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}