using System.Linq;
using System.Threading.Tasks;
using apiplate.DataBase;
using apiplate.Interfaces;
using apiplate.Models;
using apiplate.Resources;
using apiplate.Resources.Requests;
using apiplate.Utils.URI;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace apiplate.Services
{
    public class RolesService : BaseService<Role, RoleResource,RoleRequestResource>, IRolesService
    {
        public RolesService(IMapper mapper, ApiplateDbContext context, IUriService uriService) : base(mapper, context, uriService)
        {
        }

        public async Task<Role> GetRoleByTitle(string title)
        {
            return await GetDbSet().SingleOrDefaultAsync(c => c.Title.Equals(title));
        }

        protected override IQueryable<Role> GetDbSet()
        {
            return _context.Roles
            .Include(c => c.MessagesPermissions)
            .Include(c => c.AdminsPermissions)
            .Include(c => c.RolesPermissions)
            .Include(c => c.ArticlesPermissions)
            .Include(c => c.ProjectsPermissions)
            .Include(c => c.RegionsPermissions)
            .Include(c => c.SectorsPermissions)
            .Include(c => c.SlidersPermissions)
            .Include(c => c.MediaPermissions)
            .Include(c => c.VolunteersPermissions)
            .Include(c => c.PartnersPermissions)
            .Include(c => c.TestimonialsPermissions)
            .Include(c => c.TeamPermissions);
            
        }


    }
}