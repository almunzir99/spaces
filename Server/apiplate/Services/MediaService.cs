using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class MediaService : BaseService<Media, MediaResource, MediaRequestResource>, IMediaService
    {
        public MediaService(IMapper mapper, ApiplateDbContext context, IUriService uriService) : base(mapper, context, uriService)
        {
        }
        public async Task<IList<MediaResource>> UploadMultiImages(IList<ImageResource> images)
        {
            try
            {
                var mediaFiles = images.Select(img => new Media()
                {
                    Thumbnail = new Image()
                    {
                        Path = img.Path,
                        CreatedAt = img.CreatedAt,
                    },
                    Url = img.Path,
                    MediaType = "image",
                    CreatedAt = System.DateTime.Now,
                    LastUpdate = System.DateTime.Now,

                }).ToList();
                _dbSet.AddRange(mediaFiles);
                await _context.SaveChangesAsync();
                var result = _mapper.Map<IList<Media>, IList<MediaResource>>(mediaFiles);
                return result;
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
        public async Task<MediaResource> GetMainVideo()
        {
            var mainVideo = await GetDbSet().FirstOrDefaultAsync(c => c.MediaType == "video" && c.MainVideo == true);
            if (mainVideo == null)
                throw new System.Exception("no main video add");
            var result = _mapper.Map<Media, MediaResource>(mainVideo);
            return result;
        }
        protected override IQueryable<Media> GetDbSet()
        {
            return _context.Media.Include(c => c.Thumbnail);

        }
    }
}