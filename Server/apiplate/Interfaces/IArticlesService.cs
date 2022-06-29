using System.Collections.Generic;
using System.Threading.Tasks;
using apiplate.Models;
using apiplate.Resources;
using apiplate.Resources.Requests;
using apiplate.Resources.Wrappers.Filters;

namespace apiplate.Interfaces
{
        public interface IArticlesService : IBaseService<Article,ArticleResource,ArticleRequestResource>{
            Task<IList<CommentResource>> GetCommentsAsync(int articleId,PaginationFilter filter);
            Task<int> GetCommentsTotalAsync(int articleId);
            Task<CommentResource> AddCommentAsync(int articleId,CommentResource comment);
            Task DeleteCommentAsync(int id);
            
        }

    
}