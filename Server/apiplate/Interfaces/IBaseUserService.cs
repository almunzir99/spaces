using System.Collections.Generic;
using System.Threading.Tasks;
using apiplate.Models;
using apiplate.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
namespace apiplate.Interfaces
{
    public interface IBaseUserService<TModel,TResource,TResourceRequest> : IBaseService<TModel,TResource,TResourceRequest>
    where TModel:BasicUserInformation
    where TResource:BasicUserInformationResource
    {
        Task<TResource> Authenticate(AuthenticationModel model);
        Task<TResource> Register(TResourceRequest user);
        Task PasswordRecoveryRequest(string email);
        Task PasswordRecovery(string key,string newPassword);
        
        Task ResetPassword(int id,string oldPassword,string newPassword);
        Task<string> ChangePersonalPhoto(int id,IFormFile file);
        Task<TResource> UpdatePersonalInfo(int userId,JsonPatchDocument<TModel> patchDoc);
        Task<TResource> GetProfileAsync(int userId);  
    }
    
}