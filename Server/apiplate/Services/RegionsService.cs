using System.Linq;
using apiplate.DataBase;
using apiplate.Interfaces;
using apiplate.Models;
using apiplate.Resources;
using apiplate.Utils.URI;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace apiplate.Services
{
    public class RegionsService : BaseService<Region, RegionResource, RegionResource>, IRegionsService
    {
        public RegionsService(IMapper mapper, ApiplateDbContext context, IUriService uriService) : base(mapper, context, uriService)
        {
        }
        protected override IQueryable<Region> GetDbSet()
        {
            return _context.Regions
            .Include(c => c.Title).Include(c => c.Description).Include(c => c.Image);

        }
    }
}