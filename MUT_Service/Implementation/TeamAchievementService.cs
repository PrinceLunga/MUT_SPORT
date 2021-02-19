using MUT_DataAccess.DataContext;
using MUT_DataAccess.DataModels;
using MUT_MODELS;
using MUT_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MUT_Service.Implementation
{
    public class TeamAchievementService : ITeamAchievement
    {
        private readonly MUTDbContext dbContext;
        private List<TeamAchievementModel> achievements; 
        public TeamAchievementService(MUTDbContext dbContext)
        {
            this.dbContext = dbContext;
            achievements = new List<TeamAchievementModel>();
        }
        public TeamAchievement AddTeamAchievement()
        {
            throw new NotImplementedException();
        }

        public List<AchievementModel> GetTeamAchievements(int teamId)
        {
            var teamAchievement = new List<AchievementModel>();

            using (dbContext)
            {
                var results = dbContext.TeamAchievements.Where(x => x.TeamId == teamId).Select(x => new TeamAchievement
                {
                    AchievementId = x.AchievementId,
                    DateAwarded = x.DateAwarded
                }).ToList();

                if (results != null)
                {
                    foreach (var item in results)
                    {
                        teamAchievement.Add(dbContext.Achievements.Where(x => x.Id == Convert.ToInt32(item.AchievementId)).Select(x => new AchievementModel
                        {
                           Id = x.Id,
                           AchievementDescription =x.AchievementDescription,
                           DateAchieved = x.DateAchieved
                            
                        }).SingleOrDefault());
                    }
                    return teamAchievement;
                }
                return new List<AchievementModel>();
            }
        }
    }
}
