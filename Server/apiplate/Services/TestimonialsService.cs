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
    public class TestimonialsService : BaseService<Testimonial, TestimonialResource, TestimonialRequestResource>, ITestimonialsService
    {
        public TestimonialsService(IMapper mapper, ApiplateDbContext context, IUriService uriService) : base(mapper, context, uriService)
        {
        }
        protected override IQueryable<Testimonial> GetDbSet()
        {
            return _context.Testimonials
            .Include(c => c.Content).Include(c => c.Author).Include(c => c.Job).Include(c => c.Image);

        }
    }
}