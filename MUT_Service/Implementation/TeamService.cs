using MUT_DataAccess.DataContext;
using MUT_MODELS;
using MUT_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MUT_Service.Implementation
{
    public class TeamService : ITeamService
    {
        public readonly MUTDbContext dbContext;

        public TeamService(MUTDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<TeamModel> GetAllTeams()
        {
            using (dbContext)
            {
                return dbContext.Teams.Select(x => new TeamModel 
                { 
                    Id = x.Id,
                    TeamName = x.TeamName,
                    SportId = x.SportId
                }).ToList();
            }
        }
    }
}
