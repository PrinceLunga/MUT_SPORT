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

        private readonly MUTDbContext mUTDbContext;

        public TeamService(MUTDbContext mUTDbContext)
        {
            this.mUTDbContext = mUTDbContext;
        }
        public TeamModel AddTeam(TeamModel model)
        {
            using (mUTDbContext)
            {
                var sport = mUTDbContext.Sports.Where(x => x.Name.Equals(model.SportName)).SingleOrDefault();
                var Team = new Team
                {
                    CreatedBy = "Administrator",
                    DateCreated = DateTime.Now,
                    SportId = sport.Id,
                    TeamName = model.TeamName
                };
                mUTDbContext.Teams.Add(Team);
                mUTDbContext.SaveChanges();
            }
            return model;

        }

        public List<TeamModel> GetTeamByID(int TeamId)
        {
            using (mUTDbContext)
            {
                return mUTDbContext.Teams.Select(x => new TeamModel
                {
                    CreatedBy = x.CreatedBy,
                    DateCreated = x.DateCreated,
                    SportId = x.SportId,
                    TeamName = x.TeamName

                }).Where(b => b.Id == TeamId).ToList();
            }
        }

        public List<TeamModel> GetTeams()
        {
            using (mUTDbContext)
            {

                return mUTDbContext.Teams.Select(x => new TeamModel
                {
                    CreatedBy = x.CreatedBy,
                    DateCreated = x.DateCreated,
                    SportId = x.SportId,
                    TeamName = x.TeamName

                }).ToList();
            }
        }

        public void UpdateTeam(TeamModel model)
        {
            using (mUTDbContext)
            {
                var _Teams = mUTDbContext.Teams.Find(model.Id);

                if (_Teams != null)
                {
                    _Teams.TeamName = model.TeamName;
                    mUTDbContext.SaveChanges();
                }
            }
        }
    }
}
