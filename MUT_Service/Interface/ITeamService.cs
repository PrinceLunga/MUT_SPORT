using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_Service.Interface
{
    public interface ITeamService
    {

        public TeamModel AddTeam(TeamModel model);
        public List<TeamModel> GetTeamByID(int TeamId);
        public void UpdateTeam(TeamModel model);
        public List<TeamModel> GetTeams();
    }
}