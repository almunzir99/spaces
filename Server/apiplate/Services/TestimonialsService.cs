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
    public class TestimonialsService : BaseService<Testimonial, TestimonialResource, TestimonialRequestResource>, ITestimonialsService
    {
        public TestimonialsService(IMapper mapper, ApiplateDbContext context, IUriService uriService) : base(mapper, context, uriService)
        {
        }
         public async override Task DeleteAsync(int id)
        {
            try
            {
                var target = await GetDbSet().SingleOrDefaultAsync(c => c.Id == id);
                if (target == null)
                    throw new System.Exception("The target Item doesn't Exist");
                _context.Remove<Testimonial>(target);
                _context.Remove<Translation>(target.Author);
                _context.Remove<Translation>(target.Content);
                _context.Remove<Translation>(target.Job);
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
        protected override IQueryable<Testimonial> GetDbSet()
        {
            return _context.Testimonials
            .Include(c => c.Content).Include(c => c.Author).Include(c => c.Job).Include(c => c.Image);

        }
    }
}