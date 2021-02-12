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
        public StudentModel GetStudentById(string search);
        public StudentModel UpdateProfile(StudentModel studentModel);
        public List<TrainingScheduleModel> GetTrainingSchedules();
        public List<EventModel> GetAllUpcomingEvents();
        public bool StudentExists(int id);
    }
}
