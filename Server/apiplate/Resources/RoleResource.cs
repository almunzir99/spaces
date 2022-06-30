using System.ComponentModel.DataAnnotations;

namespace apiplate.Resources
{
    public class RoleResource : BaseResource
    {

        public string Title { get; set; }
        public PermissionResource MessagesPermissions { get; set; } = new PermissionResource(false, false, false, false);
        public PermissionResource AdminsPermissions { get; set; } = new PermissionResource(false, false, false, false);
        public PermissionResource RolesPermissions { get; set; } = new PermissionResource(false, false, false, false);
        public PermissionResource ArticlesPermissions { get; set; } = new PermissionResource(false, false, false, false);
        public PermissionResource SectorsPermissions { get; set; } = new PermissionResource(false, false, false, false);
        public PermissionResource RegionsPermissions { get; set; } = new PermissionResource(false, false, false, false);
        public PermissionResource SlidersPermissions { get; set; } = new PermissionResource(false, false, false, false);
        public PermissionResource TeamPermissions { get; set; } = new PermissionResource(false, false, false, false);
        public PermissionResource PartnersPermissions { get; set; } = new PermissionResource(false, false, false, false);
        public PermissionResource TestimonialsPermissions { get; set; } = new PermissionResource(false, false, false, false);

        
        


    }
}