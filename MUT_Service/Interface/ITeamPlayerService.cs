using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_Service.Interface
{
    public interface ITeamPlayerService
    {
        public List<TeamPlayerModel> GetTeamPlayers();
        public void AddNewTeamPlayer(TeamPlayerModel teamPlayerModel);
        public TeamPlayerModel GetTeamPlayerById(int Id);
        public void UpdateTeamPlayer(TeamPlayerModel teamPlayerModel);

        public bool TeamPlayerExists(int id);
    }
}
