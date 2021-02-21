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
    public class TeamPlayerService : ITeamPlayerService
    {
        private readonly MUTDbContext mUTDbContext;

        public TeamPlayerService(MUTDbContext mUTDbContext)
        {
            this.mUTDbContext = mUTDbContext;
        }
        public TeamPlayerModel AddTeamPlayer(TeamPlayerModel model)
        {
            using(mUTDbContext)
            {
                var _Student = mUTDbContext.Students.Where(x => x.Email.Equals(model.StudentEmail)).SingleOrDefault();
                var _Team = mUTDbContext.Teams.Where(c => c.TeamName.Equals(model.TeamName)).SingleOrDefault();
                var _TeamPlayer = new TeamPlayer
                {
                    CreatedBy = "Administrator",
                    DateCreated = DateTime.Now,
                    IsCaptain = model.IsCaptain,
                    IsViceCaptain = model.IsViceCaptain,
                    StudentId = _Student.Id,
                    TeamId = _Team.Id
                };
                mUTDbContext.TeamPlayers.Add(_TeamPlayer);
                mUTDbContext.SaveChanges();
            }
            return model;

        }

        public List<TeamPlayerModel> GetTeamPlayerByID(int Id)
        {
            using(mUTDbContext)
            {
                return mUTDbContext.TeamPlayers.Select(x => new TeamPlayerModel
                {
                   IsCaptain = x.IsCaptain,
                   IsViceCaptain = x.IsViceCaptain,
                   StudentId = x.StudentId,
                   TeamId = x.TeamId,
                   CreatedBy = x.CreatedBy,
                   DateCreated = x.DateCreated,
                   DateModified = x.DateModified
                   
                }).Where( b => b.Id == Id).ToList();
            }
        }

        public List<TeamPlayerModel> GetAllTeamPlayers()
        {
            using(mUTDbContext)
            {
                return mUTDbContext.TeamPlayers.Select( x => new TeamPlayerModel
                {
                  IsCaptain = x.IsCaptain,
                  IsViceCaptain = x.IsViceCaptain,
                  CreatedBy = x.CreatedBy,
                  DateModified = x.DateModified,
                  DateCreated = x.DateCreated,
                  StudentId = x.StudentId,
                  TeamId = x.TeamId
                }).ToList();
            }
        }
        public void UpdateTeamPlayer(TeamPlayerModel teamPlayerModel)
        {
            using(mUTDbContext)
            {
                var _teamPlayerModel = mUTDbContext.TeamPlayers.Find(teamPlayerModel.Id);

                if(_teamPlayerModel != null)
                {
                    _teamPlayerModel.CreatedBy = teamPlayerModel.CreatedBy;
                    _teamPlayerModel.DateCreated = teamPlayerModel.DateCreated;
                    _teamPlayerModel.DateModified = teamPlayerModel.DateModified;
                    _teamPlayerModel.IsCaptain = teamPlayerModel.IsCaptain;
                    _teamPlayerModel.IsViceCaptain = teamPlayerModel.IsViceCaptain;
                    _teamPlayerModel.StudentId = teamPlayerModel.StudentId;
                    _teamPlayerModel.TeamId = teamPlayerModel.TeamId;
                    mUTDbContext.SaveChanges();
                }
            }
        }
    }
}
