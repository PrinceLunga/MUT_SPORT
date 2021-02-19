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
    public class CoachService : ICoachService
    {
        private readonly MUTDbContext mUTDbContext;
        public CoachService(MUTDbContext _mUTDbContext)
        {
           mUTDbContext = _mUTDbContext;
        }

        public List<CoachModel> GetAllCoaches()
        {
            using (mUTDbContext)
            {
                return mUTDbContext.Coaches.Select(x => new CoachModel
                {
                    Fullnames = x.Fullnames,
                    EmailAddress = x.EmailAddress,
                    PhoneNumber = x.PhoneNumber,
                    SportName = x.SportName,
                    TeamName = x.TeamName
                }).ToList();
            }
        }

        public CoachModel GetCoachById(int id)
        {
            using (mUTDbContext)
            {
                return mUTDbContext.Coaches.Where(c => c.Id == id).Select(x => new CoachModel
                {
                    Fullnames = x.Fullnames,
                    EmailAddress = x.EmailAddress,
                    PhoneNumber = x.PhoneNumber,
                    SportName = x.SportName,
                    TeamName = x.TeamName
                }).SingleOrDefault();
            }
        }

        public CoachModel GetCoachByName(string searchString)
        {
            using (mUTDbContext)
            {
                return mUTDbContext.Coaches.Where(c => c.Fullnames.Equals(searchString)
                || c.EmailAddress.Equals(searchString)
                || c.TeamName.Equals(searchString)
                || c.SportName.Equals(searchString)
                ).Select(x => new CoachModel
                {
                    Fullnames = x.Fullnames,
                    EmailAddress = x.EmailAddress,
                    PhoneNumber = x.PhoneNumber,
                    SportName = x.SportName,
                    TeamName = x.TeamName
                }).SingleOrDefault();
            }
        }

        public void InsertNewCoach(CoachModel coachModel)
        {
            using (mUTDbContext)
            {
                int _TeamId = mUTDbContext.Teams.Where(x => x.TeamName == coachModel.TeamName).FirstOrDefault().Id;
                var coach = new Coach
                {
                    EmailAddress = coachModel.EmailAddress,
                    Fullnames = coachModel.Fullnames,
                    PhoneNumber = coachModel.PhoneNumber,
                    SportName = coachModel.SportName,
                    TeamName = coachModel.TeamName,
                    TeamId = _TeamId,
                    DateCreated = DateTime.Now

                };
                mUTDbContext.Coaches.Add(coach);
                mUTDbContext.SaveChanges();
            }
        }

        public bool CoachExists(int id)
        {
            using (mUTDbContext)
            {
                var coach = mUTDbContext.Coaches.Find(id);

                if (coach != null)
                    return true;
                else
                    return false;
            }
        }

        public void UpdateCoach(CoachModel coachModel)
        {
            using (mUTDbContext)
            {
                var coach = mUTDbContext.Coaches.Find(coachModel.Id);

                if (coach != null)
                {
                    coach.EmailAddress = coachModel.EmailAddress;
                    coach.Fullnames = coachModel.Fullnames;
                    coach.PhoneNumber = coachModel.PhoneNumber;
                    coach.SportName = coachModel.SportName;
                    coach.TeamName = coachModel.TeamName;
                }
                mUTDbContext.Coaches.Add(coach);
                mUTDbContext.SaveChanges();
            }
        }
    }

}