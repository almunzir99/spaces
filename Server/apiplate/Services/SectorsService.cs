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
    public class SectorsService : BaseService<Sector, SectorResource, SectorRequestResource>, ISectorsService
    {
        public SectorsService(IMapper mapper, ApiplateDbContext context, IUriService uriService) : base(mapper, context, uriService)
        {
        }
        public async override Task DeleteAsync(int id)
        {
            try
            {
                var target = await GetDbSet().SingleOrDefaultAsync(c => c.Id == id);
                if (target == null)
                    throw new System.Exception("The target Item doesn't Exist");
                _context.Remove<Sector>(target);
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
        protected override IQueryable<Sector> GetDbSet()
        {
            return _context.Sectors
            .Include(c => c.Title).Include(c => c.Description).Include(c => c.Image)
            .Include(c => c.Icon);

        }
    }
}