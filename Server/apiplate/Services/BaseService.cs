using apiplate.DataBase;
using apiplate.Models;
using apiplate.Interfaces;
using apiplate.Repository;
using apiplate.Resources;
using apiplate.Utils.URI;
using AutoMapper;

namespace apiplate.Services
{
    public class BaseService<TModel, TResource,TRequest> : BaseRepository<TModel, TResource,TRequest>, IBaseService<TModel, TResource,TRequest>
     where TModel : BaseModel where TResource : BaseResource
    {
        public BaseService(IMapper mapper, ApiplateDbContext context, IUriService uriSerivce) : base(mapper, context, uriSerivce){
              
          }
}
}