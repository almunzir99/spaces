using System.Linq;
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
    public class TeamService : BaseService<Team, TeamResource, TeamRequestResource>, ITeamService
    {
        public TeamService(IMapper mapper, ApiplateDbContext context, IUriService uriService) : base(mapper, context, uriService)
        {
        }
        protected override IQueryable<Team> GetDbSet()
        {
            return _context.Team
            .Include(c => c.Name).Include(c => c.Position).Include(c => c.Image);

        }
    }
}