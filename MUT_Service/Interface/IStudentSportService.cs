using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_Service.Interface
{
    public interface IStudentSportService
    {
        public void RegisterStudentToSport(StudentSportModel studentSportModel);
        public void DeregisterSport(int sportId);
        public List<StudentSportModel> GetStudentSports();
        public List<StudentSportModel> GetStudentSportsByEmail(string email);
    }
}
