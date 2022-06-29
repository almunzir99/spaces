namespace apiplate.Models
{
    public class Role : BaseModel
    {
        public string Title { get; set; }
        public Permission MessagesPermissions { get; set; }
        public Permission AdminsPermissions { get; set; }
        public Permission RolesPermissions { get; set; }
        public Permission ArticlesPermissions { get; set; }

 


    }
}