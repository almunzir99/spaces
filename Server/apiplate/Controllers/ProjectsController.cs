using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using apiplate.Helpers;
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
    public class ProjectsController : BaseController<Project, ProjectResource, ProjectRequestResource, IProjectsService>
    {
        private readonly IRolesService _roleService;

        public ProjectsController(IProjectsService service, IUriService uriService, IRolesService roleService) : base(service, uriService)
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
        [HttpGet("all")]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationFilter filter = null, [FromQuery] string title = "",
        [FromQuery] string orderBy = "LastUpdate", Boolean ascending = true,
        [FromQuery] int? sectorId = null, [FromQuery] int? regionId = null)
        {
            var validFilter = (filter == null)
          ? new PaginationFilter()
          : new PaginationFilter(pageIndex: filter.PageIndex, pageSize: filter.PageSize);
            var result = await _service.ListAsync(filter, new List<Func<Project, bool>>(), title, orderBy, ascending, sectorId, regionId);
            var totalRecords = await _service.GetTotalRecords();
            return Ok(PaginationHelper.CreatePagedResponse<ProjectResource>(result,
            validFilter, _uriSerivce, totalRecords, Request.Path.Value));
        }
        [AllowAnonymous]
        public override async Task<IActionResult> SingleAsync(int id)
        {
            var result = await base.SingleAsync(id);
            return result;
        }
        [AllowAnonymous]
        [HttpPost("{projectId}/comments")]
        public async Task<IActionResult> PostCommentAsync(int projectId, [FromBody] CommentResource comment)
        {
            try
            {
                var result = await _service.AddCommentAsync(projectId, comment);
                var response = new Response<CommentResource>(data: result, message: "comment added successfully");
                return Ok(response);
            }
            catch (System.Exception e)
            {

                var response = new Response<string>(success: false, errors: new List<string>() { e.Message });
                return BadRequest(response);
            }
        }
        [AllowAnonymous]
        [HttpGet("{projectId}/comments")]
        public async Task<IActionResult> GetCommentsAsync(int projectId, [FromQuery] PaginationFilter filter = null)
        {
            try
            {
                var result = await _service.GetCommentsAsync(projectId, filter);
                var totalRecords = await _service.GetCommentsTotalAsync(projectId);
                return Ok(PaginationHelper.CreatePagedResponse<CommentResource>(result,
                filter, _uriSerivce, totalRecords, Request.Path.Value));
            }
            catch (System.Exception e)
            {

                var response = new Response<string>(success: false, errors: new List<string>() { e.Message });
                return BadRequest(response);
            }
        }
        [Authorize(Roles = "ADMIN")]
        [HttpDelete("{projectId}/comments/{id}")]
        public async Task<IActionResult> DeleteCommentAsync(int projectId, [FromBody] int commentId)
        {
            try
            {
                await _service.DeleteCommentAsync(commentId);
                var response = new Response<CommentResource>(message: "comment deleted successfully");
                return Ok(response);
            }
            catch (System.Exception e)
            {

                var response = new Response<string>(success: false, errors: new List<string>() { e.Message });
                return BadRequest(response);
            }
        }

        protected async override Task<Permission> GetPermission(string title)
        {
            var role = await _roleService.GetRoleByTitle(title);
            if (role != null)
                return role.RolesPermissions;
            else
                throw new System.Exception("Permission isn't implemented");
        }
    }

}