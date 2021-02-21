using MUT_DataAccess.DataModels;
using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_Service.Interface
{
    public interface ITeamPlayerService
    {
        public TeamPlayerModel AddTeamPlayer(TeamPlayerModel model);
        public List<TeamPlayerModel> GetTeamPlayerByID( int AchievementId);
        public void UpdateTeamPlayer(TeamPlayerModel eventModel);
        public List<TeamPlayerModel> GetAllTeamPlayers();
    }
}
