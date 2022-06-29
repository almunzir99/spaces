namespace apiplate.Models
{
    public class Comment : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
    }
}