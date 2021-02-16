using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_Service.Interface
{
    public interface ITeamService
    {
        public List<TeamModel> GetTeams();
        public void AddNewTeam(TeamModel teamPlayerModel);
        public TeamModel GetTeamById(int Id);
        public void UpdateTeam(TeamModel teamModel);

        public bool TeamExists(int id);
    }
}
