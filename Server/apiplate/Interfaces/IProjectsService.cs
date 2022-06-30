using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using apiplate.Models;
using apiplate.Resources;
using apiplate.Resources.Requests;
using apiplate.Resources.Wrappers.Filters;

namespace apiplate.Interfaces
{
    public interface IProjectsService : IBaseService<Project, ProjectResource, ProjectRequestResource>
    {
        Task<IList<ProjectResource>> ListAsync(PaginationFilter filter, IList<Func<Project,bool>> conditions,string title ="",string orderBy ="LastUpdate",Boolean ascending = true,int? sectorId = null,int? regionId = null );
        Task<IList<CommentResource>> GetCommentsAsync(int projectId, PaginationFilter filter);
        Task<int> GetCommentsTotalAsync(int projectId);
        Task<CommentResource> AddCommentAsync(int projectId, CommentResource comment);
        Task DeleteCommentAsync(int id);

    }


}