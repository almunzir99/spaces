using System.Linq;
using System.Threading.Tasks;
using apiplate.DataBase;
using apiplate.Extensions;
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
        public async override Task DeleteAsync(int id)
        {
            try
            {
                var target = await GetDbSet().SingleOrDefaultAsync(c => c.Id == id);
                if (target == null)
                    throw new System.Exception("The target Item doesn't Exist");
                _context.Remove<Partner>(target);
                _context.Remove<Translation>(target.Name);
                _context.Remove<Image>(target.Logo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                throw new System.Exception(exception.Decode());
            }
        
        }
        protected override IQueryable<Partner> GetDbSet()
        {
            return _context.Partners.Include(c => c.Name).Include(c => c.Logo);

        }
    }
}