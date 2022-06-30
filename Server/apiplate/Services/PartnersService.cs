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
    public class PartnersService : BaseService<Partner, PartnerResource, PartnerRequestResource>, IPartnersService
    {
        public PartnersService(IMapper mapper, ApiplateDbContext context, IUriService uriService) : base(mapper, context, uriService)
        {
        }
        protected override IQueryable<Partner> GetDbSet()
        {
            return _context.Partners.Include(c => c.Name).Include(c => c.Logo);

        }
    }
}