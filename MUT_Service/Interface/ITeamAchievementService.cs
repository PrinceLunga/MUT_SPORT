using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_Service.Interface
{
    public interface ITeamAchievementService
    {
        public List<TeamAchievementModel> GetAllTeamAchievements();
        public void InsertNewTeamAchievement(TeamAchievementModel eventModel);
        public void UpdateTeamAchievement(TeamAchievementModel eventModel);
        public TeamAchievementModel GetTeamAchievementByName(string eventName);
        public bool TeamAchievementExists(int id);
        public TeamAchievementModel GetTeamAchievement(string eventName);
    }
}
