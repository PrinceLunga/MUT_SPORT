using MUT_DataAccess.DataContext;
using MUT_DataAccess.DataModels;
using MUT_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MUT_Service.Implementation
{
    public class PlayerAchievementService : IPlayerAchievement
    {
        private readonly MUTDbContext dbContext;
        private List<Achievement> achievements;
        public PlayerAchievementService(MUTDbContext dbContext)
        {
            this.dbContext = dbContext;
            achievements = new List<Achievement>();
        }
        public PlayerAchievement AddPlayerAchievement(PlayerAchievement achievement)
        {
            throw new NotImplementedException();
        }

        public List<Achievement> GetPlayerAchievements(int playerID)
        {
            using (dbContext)
            {
                var results = dbContext.PlayerAchievements.Where(x => x.PlayerId == playerID).Select(x => new PlayerAchievement
                {
                    AchievementId = x.AchievementId,
                    DateAwarded = x.DateAwarded
                }).ToList();

                if (results != null)
                {
                    foreach (var item in results)
                    {
                        achievements.Add(dbContext.Achievements.Where(x => x.Id == Convert.ToInt32(item.AchievementId)).Select(x => new Achievement
                        {
                            Id = x.Id,
                            AchievementDescription = x.AchievementDescription,
                            DateAchieved = item.DateAwarded.ToShortDateString()
                        }).SingleOrDefault());
                    }
                    return achievements;
                }
                return new List<Achievement>();
            }
        }
    }
}
