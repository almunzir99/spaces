using System.Threading.Tasks;
using apiplate.Resources;

namespace apiplate.Interfaces
{
    public interface IStatisticsService
    {
        Task<Statistics> GetStatistics();
        
    }







}