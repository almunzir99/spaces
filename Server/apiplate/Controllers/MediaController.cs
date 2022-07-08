using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using apiplate.Interfaces;
using apiplate.Models;
using apiplate.Resources;
using apiplate.Resources.Requests;
using apiplate.Resources.Wrappers.Filters;
using apiplate.Utils.URI;
using apiplate.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiplate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediaController : BaseController<Media, MediaResource, MediaRequestResource, IMediaService>
    {
        private readonly IRolesService _roleService;

        public MediaController(IMediaService service, IUriService uriService, IRolesService roleService) : base(service, uriService)
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
        [Authorize]
        [HttpPost("multi-images")]
        public async Task<IActionResult> addMultiImageAsync(IList<ImageResource> images)
        {
            try
            {
                var result = await _service.UploadMultiImages(images);
                var response = new Response<IList<MediaResource>>(data: result, success: true);
                return Ok(response);
            }
            catch (System.Exception e)
            {
                var response = new Response<MediaResource>(success: false, errors: new List<string>() { e.Message });
                return BadRequest(response);
            }
        }
        [AllowAnonymous]
        [HttpGet("main-video")]
        public async Task<IActionResult> getMainVideoAsync()
        {
            try
            {
                var result = await _service.GetMainVideo();
                var response = new Response<MediaResource>(data: result, success: true);
                return Ok(response);
            }
            catch (System.Exception e)
            {
                var response = new Response<MediaResource>(success: false, errors: new List<string>() { e.Message });
                return BadRequest(response);
            }
        }
        protected async override Task<Permission> GetPermission(string title)
        {
            var role = await _roleService.GetRoleByTitle(title);
            if (role != null)
                return role.MediaPermissions;
            else
                throw new System.Exception("Permission isn't implemented");
        }
    }

}