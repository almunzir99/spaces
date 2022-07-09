using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiplate.DataBase;
using apiplate.Extensions;
using apiplate.Interfaces;
using apiplate.Models;
using apiplate.Resources;
using apiplate.Resources.Requests;
using apiplate.Resources.Wrappers.Filters;
using apiplate.Utils.URI;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace apiplate.Services
{
    public class ArticlesService : BaseService<Article, ArticleResource, ArticleRequestResource>, IArticlesService
    {
        public ArticlesService(IMapper mapper, ApiplateDbContext context, IUriService uriService) : base(mapper, context, uriService)
        {
        }

        public async Task<CommentResource> AddCommentAsync(int articleId, CommentResource comment)
        {
            try
            {
                var target = await _context.Articles.Include(c => c.Comments).SingleOrDefaultAsync(c => c.Id == articleId);
                if (target == null)
                    throw new Exception("the target article isn't available");
                var mappedComment = _mapper.Map<CommentResource, Comment>(comment);
                target.Comments.Add(mappedComment);
                await _context.SaveChangesAsync();
                var result = _mapper.Map<Comment, CommentResource>(mappedComment);
                return result;

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async Task DeleteCommentAsync(int id)
        {
            try
            {
                var target = await _context.Comments.SingleOrDefaultAsync(c => c.Id == id);
                if (target == null)
                    throw new Exception("the target comment is not available");
                _context.Comments.Remove(target);
                await _context.SaveChangesAsync();

            }
            catch (System.Exception e)
            {

                throw e;
            }
        }

        public async Task<IList<CommentResource>> GetCommentsAsync(int articleId, PaginationFilter filter = null)
        {
            var validFilter = (filter == null) ?
            new PaginationFilter()
            : new PaginationFilter(filter.PageIndex, filter.PageSize);
            var target = await _context.Articles.Include(c => c.Comments).SingleOrDefaultAsync(c => c.Id == articleId);
            if (target == null)
                throw new Exception("the target article isn't available");
            var comments = target.Comments.Skip((validFilter.PageIndex - 1) * validFilter.PageSize)
            .Take(validFilter.PageSize).ToList();
            var result = _mapper.Map<List<Comment>, List<CommentResource>>(comments);
            return result;
        }

        public async Task<int> GetCommentsTotalAsync(int articleId)
        {
            var target = await _context.Articles.Include(c => c.Comments).SingleOrDefaultAsync(c => c.Id == articleId);
            if (target == null)
                throw new Exception("the target article isn't available");
            return target.Comments.Count();
        }
        
        public async override Task DeleteAsync(int id)
        {
            try
            {
                var target = await GetDbSet().SingleOrDefaultAsync(c => c.Id == id);
                if (target == null)
                    throw new System.Exception("The target Item doesn't Exist");
                _context.Remove<Article>(target);
                _context.Remove<Translation>(target.Title);
                _context.Remove<Translation>(target.Subtitle);
                _context.Remove<Translation>(target.Content);
                _context.Remove<Image>(target.Image);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                throw new System.Exception(exception.Decode());
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
        protected override IQueryable<Article> GetDbSet()
        {
            return _context.Articles.Include(c => c.Author)
            .Include(c => c.Title).Include(c => c.Subtitle).Include(c => c.Image)
            .Include(c => c.Content).Include(c => c.Tags).ThenInclude(c => c.Translation).Include(c => c.Comments);


        }


    }
}