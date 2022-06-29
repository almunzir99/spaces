using System.ComponentModel.DataAnnotations;

namespace apiplate.Resources.Requests
{
    public class AdminRequestResource : UserRequestResource
    {
       
        public int? RoleId { get; set; }
        
    }
}