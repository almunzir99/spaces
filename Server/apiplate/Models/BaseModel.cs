using System;

namespace apiplate.Models
{
    public abstract class BaseModel{
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdate { get; set; }
        public int? CreatedBy { get; set; }
    }
}