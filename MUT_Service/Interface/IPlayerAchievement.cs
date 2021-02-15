using MUT_DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_Service.Interface
{
    public interface IPlayerAchievement
    {
        public PlayerAchievement AddPlayerAchievement(PlayerAchievement achievement);
        public List<Achievement> GetPlayerAchievements(string playerID);
    }
}
