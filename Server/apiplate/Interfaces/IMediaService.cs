using System.Collections.Generic;
using System.Threading.Tasks;
using apiplate.Models;
using apiplate.Resources;
using apiplate.Resources.Requests;

namespace apiplate.Interfaces
{
    public interface IMediaService : IBaseService<Media, MediaResource, MediaRequestResource>
    {


        Task<IList<MediaResource>> UploadMultiImages(IList<ImageResource> images);
        Task<MediaResource> GetMainVideo();
    }


}