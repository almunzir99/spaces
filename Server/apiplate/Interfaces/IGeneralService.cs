using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiplate.Interfaces
{
    public interface IGeneralService{
        Task<object> GetCounters();
        IList<String> GetGallery();

    }
}