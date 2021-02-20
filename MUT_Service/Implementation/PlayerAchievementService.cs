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

        public List<Achievement> GetPlayerAchievements()
        {
            using (dbContext)
            {
                /*ar student = from S in dbContext.Students join TP in dbContext.TeamPlayers
                              on S.Id equals TP.StudentId join PA in dbContext.PlayerAchievements
                              on TP.Id equals PA.PlayerId join A in dbContext.Achievements
                              on PA.PlayerId equals
                              A.Id */

                var results = dbContext.PlayerAchievements.Select(x => new PlayerAchievement
                {
                    AchievementId = x.AchievementId

                }).ToList();

                if (results != null)
                {
                    foreach (var item in results)
                    {
                        achievements.Add(dbContext.Achievements.Where(x => x.Id == item.AchievementId).Select(x => new Achievement
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
