using MUT_DataAccess.DataContext;
using MUT_DataAccess.DataModels;
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
        private readonly MUTDbContext dbContext;

        public TeamService(MUTDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }
        public void AddNewTeam(TeamModel teamModel)
        {
            using (dbContext)
            {
                var team = new Team
                {
                    TeamName = teamModel.TeamName,
                    ModifiedBy = "Administration",
                    DateCreated = DateTime.Now
                };

                dbContext.Teams.Add(team);
                dbContext.SaveChanges();
            }
        }

        public TeamModel GetTeamById(int Id)
        {
            using (dbContext)
            {
                return dbContext.Teams.Where(x => x.Id == Id).Select(
                    b => new TeamModel
                    {
                        TeamName = b.TeamName,
                        ModifiedBy = b.ModifiedBy,
                    }).SingleOrDefault();
            }
        }

        public void UpdateTeam(TeamModel teamModel)
        {
            using (dbContext)
            {
                var _Team = dbContext.Teams.Find(teamModel.Id);

                if (_Team != null)
                {
                    _Team.TeamName = teamModel.TeamName;
                    _Team.DateCreated = teamModel.DateCreated;
                    _Team.ModifiedBy = teamModel.ModifiedBy;
                    _Team.DateDeleted = teamModel.DateCreated;

                    dbContext.Teams.Add(_Team);
                    dbContext.SaveChanges();
                }
            }
        }

        public List<TeamModel> GetTeams()
        {
            using (dbContext)
            {
                return dbContext.Teams.Select(x => new TeamModel
                {
                    ModifiedBy = x.ModifiedBy,
                    DateCreated = x.DateCreated,
                    TeamName = x.TeamName
                }).ToList();
            }
        }

        public bool TeamExists(int id)
        {
            using (dbContext)
            {
                var student = dbContext.Teams.Find(id);

                if (student != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
