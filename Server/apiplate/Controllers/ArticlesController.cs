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
    public class ArticlesController : BaseController<Article, ArticleResource, ArticleRequestResource, IArticlesService>
    {
        private readonly IRolesService _roleService;

        public ArticlesController(IArticlesService service, IUriService uriService, IRolesService roleService) : base(service, uriService)
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
        [AllowAnonymous]
        [HttpPost("{articleId}/comments")]
        public async Task<IActionResult> PostCommentAsync(int articleId, [FromBody] CommentResource comment)
        {
            try
            {
                var result = await _service.AddCommentAsync(articleId, comment);
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
        [HttpGet("{articleId}/comments")]
        public async Task<IActionResult> GetCommentsAsync(int articleId, [FromQuery] PaginationFilter filter = null)
        {
            try
            {
                var result = await _service.GetCommentsAsync(articleId, filter);
                var totalRecords = await _service.GetCommentsTotalAsync(articleId);
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
        [HttpDelete("{articleId}/comments/{id}")]
        public async Task<IActionResult> DeleteCommentAsync(int articleId, [FromBody] int commentId)
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