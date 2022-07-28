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
    public class VolunteersService : BaseService<Volunteer, VolunteerResource, VolunteerRequestResource>, IVolunteersService
    {
        public VolunteersService(IMapper mapper, ApiplateDbContext context, IUriService uriService) : base(mapper, context, uriService)
        {
        }
      
        protected override IQueryable<Volunteer> GetDbSet()
        {
            return _context.volunteers.Include(c => c.Sector).ThenInclude(c => c.Title);

        }
    }
}