using MUT_DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_Service.Interface
{
    public interface ITeamAchievement
    {
        public TeamAchievement AddTeamAchievement();
        public List<Achievement> GetTeamAchievements(int teamId);
    }
}
