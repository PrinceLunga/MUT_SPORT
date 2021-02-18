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
    public class AchievementService : IAchievementService
    {
        private readonly MUTDbContext mUTDbContext;

        public AchievementService(MUTDbContext mUTDbContext)
        {
            this.mUTDbContext = mUTDbContext;
        }
        public AchievementModel AddAchievement(AchievementModel model)
        {
            using(mUTDbContext)
            {
                var Achievement = new Achievement
                {
                    DateAchieved = DateTime.Now.ToString(),
                    AchievementDescription = model.AchievementDescription
                };
                mUTDbContext.Achievements.Add(Achievement);
                mUTDbContext.SaveChanges();
            }
            return model;

        }

        public List<AchievementModel> GetAchievementByID(int AchievementId)
        {
            using(mUTDbContext)
            {
                return mUTDbContext.Achievements.Select(x => new AchievementModel
                {
                    AchievementDescription = x.AchievementDescription,
                    DateAchieved = x.DateAchieved
                }).Where( b => b.Id == AchievementId).ToList();
            }
        }

        public List<AchievementModel> GetAchievements()
        {
            using(mUTDbContext)
            {
                return mUTDbContext.Achievements.Select( x => new AchievementModel 
                {
                    AchievementDescription = x.AchievementDescription,
                    DateAchieved = x.DateAchieved
                }).ToList();
            }
        }

        public void UpdateAchievement(AchievementModel achievementModel)
        {
            using(mUTDbContext)
            {
                var Achievement = mUTDbContext.Achievements.Find(achievementModel.Id);

                if(Achievement != null)
                {
                    Achievement.DateAchieved = achievementModel.DateAchieved;
                    Achievement.AchievementDescription = achievementModel.AchievementDescription;
                    mUTDbContext.SaveChanges();
                }
            }
        }
    }
}
