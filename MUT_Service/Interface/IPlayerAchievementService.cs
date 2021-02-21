using MUT_DataAccess.DataModels;
using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_Service.Interface
{
    public interface IPlayerAchievementService
    {
        public PlayerAchievementModel AddPlayerAchievement(PlayerAchievementModel model);
        public List<PlayerAchievementModel> GetPlayerAchievementByID(int Id);
        public void UpdatePlayerAchievement(PlayerAchievementModel eventModel);
        public List<PlayerAchievementModel> GetPlayersAchievements();
    }
}
