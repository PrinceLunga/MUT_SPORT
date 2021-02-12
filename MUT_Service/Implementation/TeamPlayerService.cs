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
        private readonly MUTDbContext dbContext;

        public TeamPlayerService(MUTDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }
        public void AddNewTeamPlayer(TeamPlayerModel teamPlayerModel)
        {
            using (dbContext)
            {
                var teamPlayer = new TeamPlayer
                {
                    IsCaptain = teamPlayerModel.IsCaptain,
                    CreatedBy = teamPlayerModel.CreatedBy,
                    DateCreated = DateTime.Now,
                    StudentId = teamPlayerModel.StudentId,
                    TeamId = teamPlayerModel.TeamId,
                    IsViceCaptain = teamPlayerModel.IsViceCaptain
                };

                dbContext.TeamPlayers.Add(teamPlayer);
                dbContext.SaveChanges();
            }
        }

        public TeamPlayerModel GetTeamPlayerById(int Id)
        {
            using (dbContext)
            {
                return dbContext.TeamPlayers.Where(x => x.Id == Id).Select(
                    b => new TeamPlayerModel
                    {
                        IsCaptain = b.IsCaptain,
                        IsViceCaptain = b.IsViceCaptain,
                        CreatedBy = b.CreatedBy,
                        DateModified = b.DateModified
                    }).SingleOrDefault();
            }
        }

        public List<TeamPlayerModel> GetTeamById(int Id)
        {
            using (dbContext)
            {
                return dbContext.TeamPlayers.Where(x => x.TeamId == Id).Select(
                    b => new TeamPlayerModel
                    {
                        IsCaptain = b.IsCaptain,
                        IsViceCaptain = b.IsViceCaptain,
                        CreatedBy = b.CreatedBy,
                        DateModified = b.DateModified
                    }).ToList();
            }
        }

        public void UpdateTeamPlayer(TeamPlayerModel teamPlayerModel)
        {
            using(dbContext)
            {
                var _TeamPlayer = dbContext.TeamPlayers.Find(teamPlayerModel.Id);

                if(_TeamPlayer != null)
                {
                    _TeamPlayer.IsCaptain = teamPlayerModel.IsCaptain;
                    _TeamPlayer.IsViceCaptain = teamPlayerModel.IsViceCaptain;
                    _TeamPlayer.DateModified = DateTime.Now;

                    dbContext.TeamPlayers.Add(_TeamPlayer);
                    dbContext.SaveChanges();
                }
            }
        }

        public List<TeamPlayerModel> GetTeamPlayers()
        {
            using(dbContext)
            {
                return dbContext.TeamPlayers.Select(x => new TeamPlayerModel
                {
                    CreatedBy = x.CreatedBy,
                    DateCreated = x.DateCreated,
                    DateModified = x.DateModified,
                    IsCaptain = x.IsCaptain,
                    IsViceCaptain = x.IsViceCaptain                   
                }).ToList();
            }
        }
        public bool TeamPlayerExists(int id)
        {
            using (dbContext)
            {
                var student = dbContext.TeamPlayers.Find(id);

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
