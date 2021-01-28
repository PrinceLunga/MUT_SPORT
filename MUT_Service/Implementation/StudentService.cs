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
    public class StudentService : IStudentService
    {
        private readonly MUTDbContext mUTDbcontext;

        public StudentService(MUTDbContext _mUTDbcontext)
        {
            this.mUTDbcontext = _mUTDbcontext;
        }
        public void AddStudent(StudentModel model)
        {
            using(mUTDbcontext)
            {
                var student = new Student
                {
                    Fullnames = model.Fullnames,
                    Accomodation = model.Accomodation,
                    PhoneNumber = model.PhoneNumber,
                    HasMedicalAid = model.HasMedicalAid,
                    MedicalAidCard = model.MedicalAidCard,
                    MedicalAidNumber = model.MedicalAidNumber,
                    NextOfKinFullnames = model.NextOfKinFullnames,
                    NextOfKinPhoneNumber = model.NextOfKinPhoneNumber,
                    SportId = model.SportId,
                    DateCreated = DateTime.Now
                };
            }
        }

        public List<StudentModel> GetAllStudents()
        {
            using(mUTDbcontext)
            {
                return mUTDbcontext.Students.Select( x => new StudentModel 
                { 
                    Fullnames = x.Fullnames,
                    Accomodation = x.Accomodation,
                    HasMedicalAid = x.HasMedicalAid,
                    MedicalAidCard = x.MedicalAidCard,
                    MedicalAidNumber = x.NextOfKinFullnames,
                    NextOfKinPhoneNumber = x.NextOfKinPhoneNumber,
                    PhoneNumber = x.PhoneNumber,
                    NextOfKinFullnames = x.NextOfKinFullnames,
                    SportId = x.SportId
                }).ToList();
            }
        }

        public List<EventModel> GetAllUpcomingEvents()
        {
            throw new NotImplementedException();
        }

        public StudentModel GetStudentById(string search)
        {
            using(mUTDbcontext)
            {
                return mUTDbcontext.Students
                    .Where(x => x.Fullnames == search || x.Id == Convert.ToInt32(search))
                    .Select(b => new StudentModel
                    {
                        MedicalAidCard = b.MedicalAidCard,
                        MedicalAidNumber = b.MedicalAidNumber,
                        Fullnames = b.Fullnames,
                        Accomodation = b.Accomodation,
                        HasMedicalAid = b.HasMedicalAid,
                        PhoneNumber = b.PhoneNumber,
                        NextOfKinFullnames = b.NextOfKinFullnames,
                        NextOfKinPhoneNumber = b.NextOfKinPhoneNumber,
                        SportId = b.SportId,
                        DateCreated = b.DateCreated

                    }).FirstOrDefault();
                    
            }
        }

        public List<TrainingScheduleModel> GetTrainingSchedules()
        {
            throw new NotImplementedException();
        }

        public StudentModel UpdateProfile(StudentModel studentModel)
        {
            throw new NotImplementedException();
        }
    }
}
