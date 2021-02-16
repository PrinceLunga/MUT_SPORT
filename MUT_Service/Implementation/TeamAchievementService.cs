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
    public class TeamAchievementService : ITeamAchievementService
    {
        private readonly MUTDbContext mUTDbContext;
        public TeamAchievementService(MUTDbContext _mUTDbContext)
        {
            this.mUTDbContext = _mUTDbContext;
        }

        public bool TeamAchievementExists(int id)
        {
            using(mUTDbContext)
            {
                var _Event = mUTDbContext.TeamAchievements.Find(id);

                if(_Event == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<TeamAchievementModel> GetAllTeamAchievements()
        {
            using (mUTDbContext)
            {
                return mUTDbContext.TeamAchievements.Select(x => new TeamAchievementModel
                {
                   Id = x.Id,
                   CreatedBy = x.CreatedBy,
                   DateCreated = x.DateCreated
                }).ToList();
            }
        }

        public TeamAchievementModel GetTeamAchievementByName(string eventName)
        {
            using (mUTDbContext)
            {
                return mUTDbContext.TeamAchievements.Where(x => x.Achievement.Id.Equals(eventName)).Select(x => new TeamAchievementModel
                {
                    CreatedBy = x.CreatedBy,
                    DateCreated = x.DateCreated,
                    Achievement = new AchievementModel
                    {
                        AchievementDescription = x.Achievement.AchievementDescription,
                        DateAchieved = x.Achievement.DateAchieved,
                        AchievementId = x.Achievement.AchievementId
                    }
                }).Single();
            }
        }

        public void InsertNewEvent(TeamAchievementModel _TeamAchievement)
        {
            using (mUTDbContext)
            {
                var _teamAchievement = new TeamAchievement
                {
                    DateCreated = _TeamAchievement.DateCreated,
                    CreatedBy = _TeamAchievement.CreatedBy,
                    Team = new Team
                    {
                        TeamName = _TeamAchievement.Team.TeamName,
                        DateCreated = _TeamAchievement.Team.DateCreated,
                        ModifiedBy = _TeamAchievement.Team.ModifiedBy
                    }
                };
                mUTDbContext.Add(_teamAchievement);
                mUTDbContext.SaveChanges();
            }


        }

        public void UpdateEvent(EventModel eventModel)
        {
            using (mUTDbContext)
            {
                var _event = mUTDbContext.Events.Find(eventModel.Id);

                _event.Name = eventModel.Name;
                _event.Venue = eventModel.Venue;
                _event.StartingTime = eventModel.StartingTime;
                _event.EndingTime = eventModel.EndingTime;
                mUTDbContext.SaveChanges();

            }
        }

        public void InsertNewTeamAchievement(TeamAchievementModel eventModel)
        {
            throw new NotImplementedException();
        }

        public void UpdateTeamAchievement(TeamAchievementModel eventModel)
        {
            throw new NotImplementedException();
        }

        public TeamAchievementModel GetTeamAchievement(string AchievementName)
        {
            using(mUTDbContext)
            {
                return mUTDbContext.TeamAchievements.Select
                    (
                            b => new TeamAchievementModel { Id = b.Id, CreatedBy = b.CreatedBy, DateCreated = b.DateCreated }
                    ).Where(x => x.Achievement.AchievementDescription.Equals(AchievementName)).SingleOrDefault();
            }
        }
    }



}