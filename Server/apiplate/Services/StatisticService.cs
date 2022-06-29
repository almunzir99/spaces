using System.Threading.Tasks;
using apiplate.DataBase;
using apiplate.Interfaces;
using apiplate.Resources;
using Microsoft.EntityFrameworkCore;

namespace apiplate.Services
{
    public class StatisticsService : IStatisticsService
    {   
        private readonly ApiplateDbContext _context;

        public StatisticsService(ApiplateDbContext context)
        {
            _context = context;
        }

        public async Task<Statistics> GetStatistics()
        {
            var stats = new Statistics();
            stats.Messages = await _context.Messages.CountAsync();
            stats.Admins = await _context.Users.CountAsync();
            stats.Roles = await _context.Roles.CountAsync();
            return stats;






        }
    }
}