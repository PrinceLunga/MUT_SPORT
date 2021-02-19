using MUT_MODELS;
using MUT_Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_Service.Implementation
{
    public class CoachService : ICoachService
    {
        public bool CoachExists(int id)
        {
            throw new NotImplementedException();
        }

        public List<CoachModel> GetAllCoaches()
        {
            throw new NotImplementedException();
        }

        public CoachModel GetCoachById(int id)
        {
            throw new NotImplementedException();
        }

        public CoachModel GetCoachByName(string searchString)
        {
            throw new NotImplementedException();
        }

        public void InsertNewCoach(CoachModel coachModel)
        {
            throw new NotImplementedException();
        }

        public void UpdateCoach(CoachModel coachModel)
        {
            throw new NotImplementedException();
        }
    }
}
