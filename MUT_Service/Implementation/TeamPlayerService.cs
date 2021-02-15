using MUT_DataAccess.DataContext;
using MUT_DataAccess.DataModels;
using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MUT_Service.Interface
{
    public class TeamPlayerService : ITeamPlayerService
    {
        private readonly MUTDbContext mUTDBContext;

        public TeamPlayerService(MUTDbContext mUTDBContext)
        {
            this.mUTDBContext = mUTDBContext;
        }
        public void AddNewTeamPlayer(TeamPlayerModel teamPlayerModel)
        {
            using (mUTDBContext)
            {
                var _TeamPLayer = new TeamPlayer
                {
                    IsCaptain = teamPlayerModel.IsCaptain,
                    IsViceCaptain = teamPlayerModel.IsViceCaptain,
                    CreatedBy = teamPlayerModel.CreatedBy,
                };

                mUTDBContext.SaveChanges();
            }
        }
        public TeamPlayerModel GetTeamPlayerById(int Id)
        {
            using (mUTDBContext)
            {
                return mUTDBContext.TeamPlayers.Select(b => new TeamPlayerModel
                {
                    IsCaptain = b.IsCaptain,
                    CreatedBy = b.CreatedBy,
                    IsViceCaptain = b.IsViceCaptain
                }).Where(x => x.Id == Id).SingleOrDefault();
            }
        }

        public List<TeamPlayerModel> GetTeamPlayers()
        {
            using (mUTDBContext)
            {
                return mUTDBContext.TeamPlayers.Select(x => new TeamPlayerModel
                {
                    IsCaptain = x.IsCaptain,
                    IsViceCaptain = x.IsViceCaptain,
                    CreatedBy = x.CreatedBy,
                    DateCreated = x.DateCreated,
                    DateModified = x.DateModified
                }).ToList();
            }
        }

        public bool TeamPlayerExists(int id)
        {
            using (mUTDBContext)

            {
                var _TeamPlayer = mUTDBContext.TeamPlayers.Find(id);

                if (_TeamPlayer != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void UpdateTeamPlayer(TeamPlayerModel teamPlayerModel)
        {
            using (mUTDBContext)
            {
                var _TeamPlayer = mUTDBContext.TeamPlayers.Find(teamPlayerModel.Id);

                if (_TeamPlayer != null)
                {
                    _TeamPlayer.IsCaptain = teamPlayerModel.IsCaptain;
                    _TeamPlayer.IsViceCaptain = teamPlayerModel.IsViceCaptain;
                    _TeamPlayer.CreatedBy = teamPlayerModel.CreatedBy;
                    _TeamPlayer.DateModified = teamPlayerModel.DateModified;
                    mUTDBContext.SaveChanges();
                }
            }
        }
    }
}                                                  