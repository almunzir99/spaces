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
    public class RegionsService : BaseService<Region, RegionResource, RegionRequestResource>, IRegionsService
    {
        public RegionsService(IMapper mapper, ApiplateDbContext context, IUriService uriService) : base(mapper, context, uriService)
        {
        }
        public async override Task DeleteAsync(int id)
        {
            try
            {
                var target = await GetDbSet().SingleOrDefaultAsync(c => c.Id == id);
                if (target == null)
                    throw new System.Exception("The target Item doesn't Exist");
                _context.Remove<Region>(target);
                _context.Remove<Translation>(target.Title);
                _context.Remove<Translation>(target.Description);
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
        protected override IQueryable<Region> GetDbSet()
        {
            return _context.Regions
            .Include(c => c.Title).Include(c => c.Description).Include(c => c.Image);

        }
    }
}