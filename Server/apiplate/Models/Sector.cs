using System.Collections.Generic;

namespace apiplate.Models
{
    public class Sector : BaseModel
    {
        public int TitleId { get; set; }
        public Translation Title { get; set; }
        
        public int DescriptionId { get; set; }
        public Translation Description { get; set; }
        public int IconId { get; set; }
        public Image Icon { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
        public IList<Project> Projects { get; set; }
    }
}