using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_Service.Interface
{
    public interface ICoachService
    {
        public List<CoachModel> GetAllCoaches();
        public void InsertNewCoach(CoachModel coachModel);
        public void UpdateCoach(CoachModel coachModel);
        public CoachModel GetCoachByName(string searchString);
        public CoachModel GetCoachById(int id);
        public bool CoachExists(int id);
    }
}
