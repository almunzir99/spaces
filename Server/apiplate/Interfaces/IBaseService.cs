using apiplate.Models;
using apiplate.Repository;
using apiplate.Resources;

namespace apiplate.Interfaces
{
    public interface IBaseService<TModel,TResource,TRequest> : IRepository<TModel,TResource,TRequest>
    where TModel:BaseModel
    where TResource : BaseResource
    {
        
    }
}