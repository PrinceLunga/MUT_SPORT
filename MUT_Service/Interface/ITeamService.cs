using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_Service.Interface
{
    public interface ITeamService
    {
        public List<TeamModel> GetAllTeams();
    }
}
