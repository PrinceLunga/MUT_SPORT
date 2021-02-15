using MUT_DataAccess.DataModels;
using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_Service.Interface
{
    public interface IStudentService
    {
        public List<StudentModel> GetAllStudents();
        public void AddStudent(StudentModel model);
        public StudentSport RegisterSport(StudentSportModel model);
        public string DeregisterSport(StudentSportModel model);
        public StudentModel GetStudentById(string username);
        public List<StudentSport> GetRegisteredStudents(int sportId, string studentId);
        public StudentModel UpdateProfile(StudentModel studentModel);
        public List<TrainingScheduleModel> GetTrainingSchedules();
        public List<UpComingEventsModel> GetAllUpcomingEvents();
        public bool StudentExists(string username);

    }
}
