using System.Threading.Tasks;
using apiplate.Models;
using apiplate.Resources;
using apiplate.Resources.Requests;

namespace apiplate.Interfaces
{
    public interface IRolesService: IBaseService<Role,RoleResource,RoleRequestResource>{
        Task<Role> GetRoleByTitle(string title);
        
    }
}