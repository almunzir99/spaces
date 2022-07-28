using System.Threading.Tasks;
using apiplate.Models;
using apiplate.Interfaces;
using apiplate.Resources;
using apiplate.Resources.Requests;
using apiplate.Utils.URI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiplate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VolunteersController : BaseController<Volunteer, VolunteerResource,VolunteerRequestResource, IVolunteersService>
    {
        private readonly IRolesService _roleService;
        private readonly INotificationService _notificationService;

        public VolunteersController(IVolunteersService service, IUriService uriSerivce, IRolesService roleService, INotificationService notificationService) : base(service, uriSerivce)
        {
            _roleService = roleService;
            _notificationService = notificationService;
        }

        [AllowAnonymous]
        [HttpPost]
        public override async Task<IActionResult> PostAsync([FromBody] VolunteerRequestResource body){
             // Push Notifications
                var notification = new NotificationResource(){
                    Title = "New Volunteer",
                    Message ="There is a new Volunteer Request submitted, please check Volunteers page",
                    Module = "VOLUNTEER",
                    Action = "CREATE",
                    Url = "/dashboard/Volunteers"
                };
                await _notificationService.BroadCastNotification(notification,"admin");
            return await base.PostAsync(body);
        }
        protected async override Task<Permission> GetPermission(string title)
        {
            var role = await _roleService.GetRoleByTitle(title);
            if (role != null)
                return role.VolunteersPermissions;
            else
                throw new System.Exception("Permission isn't implemented");
        }
    }

}