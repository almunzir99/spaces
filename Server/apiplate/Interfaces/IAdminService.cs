using apiplate.Models;
using apiplate.Resources;
using apiplate.Resources.Requests;

namespace apiplate.Interfaces
{
    public interface IAdminService : IBaseUserService<Admin,AdminResource,AdminRequestResource>
    {
        
    }
    
}