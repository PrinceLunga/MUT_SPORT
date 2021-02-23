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
    public class PlayerAchievementService : IPlayerAchievementService
    {
        private readonly MUTDbContext dbContext;
        private List<Achievement> achievements;
        public PlayerAchievementService(MUTDbContext dbContext)
        {
            this.dbContext = dbContext;
            achievements = new List<Achievement>();
        }
        public PlayerAchievementModel AddPlayerAchievement(PlayerAchievementModel playerAchievement)
        {
            using (dbContext)
            {
                var achievement = dbContext.Achievements.Where(x => x.AchievementDescription.Equals(playerAchievement.AchievementDesc)).SingleOrDefault();
                var student = dbContext.Students.Where(x => x.Email.Equals(playerAchievement.PlayerName)).SingleOrDefault();
                var teamPlayer = dbContext.TeamPlayers.Where(b => b.StudentId == Convert.ToInt32("4")
                || b.TeamId == Convert.ToInt32("1")).SingleOrDefault();
                int PlayerId = teamPlayer.Id;
                var _PlayerAchievment = new PlayerAchievement
                {
                    AchievementId = achievement.Id,
                    DateAwarded = DateTime.Now,
                    PlayerId = PlayerId
                };

                dbContext.PlayerAchievements.Add(_PlayerAchievment);
                dbContext.SaveChanges();
            }
            return playerAchievement;
        }

        public List<PlayerAchievementModel> GetPlayerAchievementByID(int Id)
        {
            using(dbContext)
            {
                return dbContext.PlayerAchievements.Select( b => new PlayerAchievementModel 
                { 
                    AchievementId = b.AchievementId,
                    PlayerId = b.PlayerId,
                    DateAwarded = b.DateAwarded,
                }).Where(x => x.Id == Id
               || x.PlayerId == Id).ToList();
            }
        }

        public List<PlayerAchievementModel> GetPlayerAchievements(int playerID)
        {
            using (dbContext)
            {
                return dbContext.PlayerAchievements.Where(x => x.PlayerId == playerID).Select(c => new PlayerAchievementModel
                {
                    PlayerId = c.PlayerId,
                    AchievementId = c.AchievementId,
                    DateAwarded = c.DateAwarded
                }).ToList();
            }
        }

        public List<PlayerAchievementModel> GetPlayersAchievements()
        {
            using(dbContext)
            {
                return dbContext.PlayerAchievements.Select( c => new PlayerAchievementModel
                {
                    AchievementId = c.AchievementId,
                    PlayerId = c.PlayerId,
                    DateAwarded = c.DateAwarded
                }).ToList();
            }
        }

        public void UpdatePlayerAchievement(PlayerAchievementModel playerAchievementModel)
        {
           using(dbContext)
            {
                var _PlayerAchievement = dbContext.PlayerAchievements.Find(playerAchievementModel.Id);

                _PlayerAchievement.PlayerId = playerAchievementModel.PlayerId;
                _PlayerAchievement.AchievementId = playerAchievementModel.AchievementId;
                dbContext.SaveChanges();
            }
        }
    }
}
