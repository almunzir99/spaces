using System;
using System.Threading.Tasks;
using apiplate.Models;
using apiplate.Interfaces;
using apiplate.Resources;
using apiplate.Resources.Wrappers.Filters;
using Microsoft.AspNetCore.Mvc;

namespace apiplate.Controllers
{
    public interface IBaseController<TModel, TResource, TRequest ,TService>
    where TModel : BaseModel where TResource : BaseResource where TService : IBaseService<TModel, TResource,TRequest>
    {
        Task<IActionResult> GetAsync(PaginationFilter filter = null,string title="",[FromQuery] string orderBy = "LastUpdate",Boolean ascending = true);
        Task<IActionResult> SingleAsync(int id);
        Task<IActionResult> PostAsync(TRequest body);
        Task<IActionResult> PutAsync(int id, TRequest body);
        Task<IActionResult> DeleteAsync(int id);
    }
}