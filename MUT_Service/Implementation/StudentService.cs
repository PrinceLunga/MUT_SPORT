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
            using (mUTDbcontext)
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
                    DateCreated = DateTime.Now
                };
            }
        }

        public List<StudentModel> GetAllStudents()
        {
            using (mUTDbcontext)
            {
                return mUTDbcontext.Students.Select(x => new StudentModel
                {
                    Fullnames = x.Fullnames,
                    Accomodation = x.Accomodation,
                    HasMedicalAid = x.HasMedicalAid,
                    MedicalAidCard = x.MedicalAidCard,
                    MedicalAidNumber = x.NextOfKinFullnames,
                    NextOfKinPhoneNumber = x.NextOfKinPhoneNumber,
                    PhoneNumber = x.PhoneNumber,
                    NextOfKinFullnames = x.NextOfKinFullnames
                }).ToList();
            }
        }

        public List<EventModel> GetAllUpcomingEvents()
        {
            using (mUTDbcontext)
            {
                return mUTDbcontext.Events.Select(x => new EventModel
                {
                    Name = x.Name,
                    Venue = x.Venue,
                    StartingTime = x.StartingTime,
                    EndingTime = x.EndingTime
                }).ToList();
            }
        }

        public StudentModel GetStudentById(string search)
        {
            using (mUTDbcontext)
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
                        DateCreated = b.DateCreated

                    }).FirstOrDefault();

            }
        }

        public List<TrainingScheduleModel> GetTrainingSchedules()
        {
            using (mUTDbcontext)
            {
                return mUTDbcontext.TrainingSchedules.Select(x => new TrainingScheduleModel
                {
                    Venue = x.Venue,
                    StartTime = x.StartTime,
                    FinishTime = x.FinishTime,
                    DateOfSession = x.DateOfSession
                }).ToList();
            }
        }

        public bool StudentExists(int id)
        {
            using (mUTDbcontext)
            {
                var student = mUTDbcontext.Students.Find(id);

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

        public StudentModel UpdateProfile(StudentModel studentModel)
        {
            using (mUTDbcontext)
            {
                var student = mUTDbcontext.Students.Find(studentModel.Id);

                if (student != null)
                {
                    student.MedicalAidCard = studentModel.MedicalAidCard;
                    student.MedicalAidNumber = studentModel.MedicalAidNumber;
                    student.NextOfKinFullnames = studentModel.NextOfKinFullnames;
                    student.NextOfKinPhoneNumber = studentModel.NextOfKinPhoneNumber;
                    student.PhoneNumber = studentModel.PhoneNumber;
                    student.Fullnames = studentModel.Fullnames;
                    student.DateModified = DateTime.Now;
                    student.Accomodation = studentModel.Accomodation;
                    mUTDbcontext.SaveChanges();
                    return studentModel;
                }
                else
                {
                    return new StudentModel();
                }
            }
        }
    }
}
