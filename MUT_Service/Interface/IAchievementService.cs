using MUT_DataAccess.DataModels;
using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_Service.Interface
{
    public interface IAchievementService
    {
        public AchievementModel AddAchievement(AchievementModel model);
        public List<AchievementModel> GetAchievementByID( int AchievementId);
        public void UpdateAchievement(AchievementModel eventModel);
        public List<AchievementModel> GetAchievements();
    }
}
