using System;
using System.Threading.Tasks;
using apiplate.Interfaces;
using apiplate.Models;
using apiplate.Resources;
using apiplate.Resources.Requests;
using apiplate.Resources.Wrappers.Filters;
using apiplate.Utils.URI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiplate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SlidersController : BaseController<Slider, SliderResource, SliderRequestResource, ISlidersService>
    {
        private readonly IRolesService _roleService;

        public SlidersController(ISlidersService service, IUriService uriService, IRolesService roleService) : base(service, uriService)
        {
            _roleService = roleService;
        }

        [AllowAnonymous]
        public async override Task<IActionResult> GetAsync([FromQuery] PaginationFilter filter = null, [FromQuery] string title = "", [FromQuery] string orderBy = "LastUpdate", Boolean ascending = true)
        {
            var result = await base.GetAsync(filter, title, orderBy, ascending);
            return result;
        }
        [AllowAnonymous]
        public override async Task<IActionResult> SingleAsync(int id)
        {
            var result = await base.SingleAsync(id);
            return result;
        }
        protected async override Task<Permission> GetPermission(string title)
        {
            var role = await _roleService.GetRoleByTitle(title);
            if (role != null)
                return role.SlidersPermissions;
            else
                throw new System.Exception("Permission isn't implemented");
        }
    }

}