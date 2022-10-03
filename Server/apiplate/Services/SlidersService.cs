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
    public class SlidersService : BaseService<Slider, SliderResource, SliderRequestResource>, ISlidersService
    {
        public SlidersService(IMapper mapper, ApiplateDbContext context, IUriService uriService) : base(mapper, context, uriService)
        {
        }
        public async override Task DeleteAsync(int id)
        {
            try
            {
                var target = await GetDbSet().SingleOrDefaultAsync(c => c.Id == id);
                if (target == null)
                    throw new System.Exception("The target Item doesn't Exist");
                _context.Remove<Slider>(target);
                _context.Remove<Translation>(target.Title);
                _context.Remove<Translation>(target.Subtitle);
                _context.Remove<Translation>(target.Description);
                _context.Remove<Image>(target.Image);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                throw new System.Exception(exception.Decode());
            }
        
        }
        protected override IQueryable<Slider> GetDbSet()
        {
            return _context.Sliders
            .Include(c => c.Title).Include(c => c.Subtitle).Include(c => c.Description).Include(c => c.Image);

        }
    }
}