using System;

namespace apiplate.Models
{
    public class Image 
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}