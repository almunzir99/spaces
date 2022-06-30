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
    public class SlidersService : BaseService<Slider, SliderResource, SliderRequestResource>, ISlidersService
    {
        public SlidersService(IMapper mapper, ApiplateDbContext context, IUriService uriService) : base(mapper, context, uriService)
        {
        }
        protected override IQueryable<Slider> GetDbSet()
        {
            return _context.Sliders
            .Include(c => c.Title).Include(c => c.Subtitle).Include(c => c.Description).Include(c => c.Image);

        }
    }
}