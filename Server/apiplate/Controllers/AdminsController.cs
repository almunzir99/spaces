

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiplate.Models;
using apiplate.Interfaces;
using apiplate.Resources;
using apiplate.Resources.Requests;
using apiplate.Resources.Wrappers.Filters;
using apiplate.Utils.URI;
using apiplate.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace apiplate.Controllers
{
    public class AdminsController : BaseUserController<Admin, AdminResource, AdminRequestResource ,IAdminService>
    {
        private readonly IRolesService _roleService;
        public AdminsController(IAdminService service, IUriService uriService, IRolesService roleService,INotificationService _notificationsService) : base(service, uriService, _notificationsService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public override async Task<IActionResult> GetAsync([FromQuery] PaginationFilter filter = null, [FromQuery] string title = "", [FromQuery] string orderBy = "LastUpdate", Boolean ascending = true)
        {

            var actionResult = await base.GetAsync(filter, title, orderBy, ascending);
            if(actionResult is OkObjectResult)
            {
                var okActionResult = actionResult as OkObjectResult;
                var response = okActionResult.Value as PagedResponse<IList<AdminResource>>;
                response.Data = response.Data.Where(c => c.IsManager == false && c.Id != GetCurrentUserId()).ToList();
            }
            return actionResult;
        }
        protected override string type => "ADMIN";

        protected async override Task<Permission> GetPermission(string title)
        {
            var role = await _roleService.GetRoleByTitle(title);
            if (role != null)
                return role.AdminsPermissions;
            else
                throw new System.Exception("Permission isn't implemented");
        }
    }
}