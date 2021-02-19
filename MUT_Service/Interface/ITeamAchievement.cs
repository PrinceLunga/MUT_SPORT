using MUT_DataAccess.DataModels;
using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_Service.Interface
{
    public interface ITeamAchievement
    {
        public TeamAchievement AddTeamAchievement();
        public List<AchievementModel> GetTeamAchievements(int teamId);
    }
}
