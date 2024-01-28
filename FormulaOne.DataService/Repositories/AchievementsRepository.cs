using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repositories
{
    public class AchievementsRepository : GenericRepository<Achievement>, IAchievementsRepository
    {
        public AchievementsRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public async Task<Achievement?> GetDriverAchievementAsync(Guid driverId)
        {
            try
            {
                return await _dbSet.FirstOrDefaultAsync(x => x.DriverId == driverId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(AchievementsRepository));
                throw;
            }
        }

        public override async Task<IEnumerable<Achievement>> GetAll()
        {
            try
            {
                return await _dbSet.Where(x => x.State == 1)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(x => x.AddedDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(AchievementsRepository));
                throw;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

                if (result == null)
                    return false;

                result.State = 0;
                result.UpdatedDate = DateTime.Now;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(AchievementsRepository));
                throw;
            }
        }

        public override async Task<bool> Update(Achievement  achievement)
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == achievement.Id);

            if (result == null)
                return false;

            result.UpdatedDate = DateTime.UtcNow;
            result.FastedLap = achievement.FastedLap;
            result.PolePosition = achievement.PolePosition;
            result.RaceWin = achievement.RaceWin;
            result.WorldChampionShip = achievement.WorldChampionShip;

            return true;
        }
    }
}
