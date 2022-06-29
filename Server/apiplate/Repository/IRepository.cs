using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using apiplate.Models;
using apiplate.Resources;
using apiplate.Resources.Wrappers.Filters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace apiplate.Repository
{
    public interface IRepository<TModel,TResource,TRequest> 
    where TModel:BaseModel
    where TResource : BaseResource
    {
        Task<IList<TResource>> ListAsync(PaginationFilter filter, IList<Func<TModel,bool>> conditions,string title ="",string orderBy ="LastUpdate",Boolean ascending = true);
        Task<TResource> SingleAsync(int id);
        Task<TResource> CreateAsync(TRequest newItem, int userId);
        Task<TResource> UpdateAsync(int id, TRequest newItem);
        Task<TResource> UpdateAsync(int id, JsonPatchDocument<TModel> newItem);
        Task DeleteAsync(int id);
        Task<FileContentResult> ExportToCSV(); 
        Task<int> GetTotalRecords();
         Task CreateActivity(int userId,int rowId,string action);
    }
}