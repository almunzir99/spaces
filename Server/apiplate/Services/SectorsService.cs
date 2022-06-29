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
    public class SectorsService : BaseService<Sector, SectorResource, SectorRequestResource>, ISectorsService
    {
        public SectorsService(IMapper mapper, ApiplateDbContext context, IUriService uriService) : base(mapper, context, uriService)
        {
        }
        protected override IQueryable<Sector> GetDbSet()
        {
            return _context.Sectors
            .Include(c => c.Title).Include(c => c.Description).Include(c => c.Image)
            .Include(c => c.Icon);

        }
    }
}