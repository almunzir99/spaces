using System.ComponentModel.DataAnnotations;

namespace apiplate.Resources.Requests
{
    public class RoleRequestResource
    {
        [Required]
        public string Title { get; set; }
        public PermissionResource MessagesPermissions { get; set; } = new PermissionResource(false, false, false, false);
        public PermissionResource AdminsPermissions { get; set; } = new PermissionResource(false, false, false, false);
        public PermissionResource RolesPermissions { get; set; } = new PermissionResource(false, false, false, false);

    }
}