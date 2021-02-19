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
                    StudentNumber = model.StudentNumber,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    Email = model.Email,
                    StudyLevel = model.StudyLevel,
                    Qualification = model.Qualification,
                    Accomodation = model.Accomodation,
                    PhoneNumber = model.PhoneNumber,
                    NextOfKinPhoneNumber = model.NextOfKinPhoneNumber,
                    DateCreated = model.DateCreated,
                    MedicalAidCardPic = model.MedicalAidCardPic,
                    DisplayPicture = model.DisplayPicture,
                    HasMedicalAid = model.HasMedicalAid,
                    MedicalAidNumber = model.MedicalAidNumber,
                    NextOfKinFullnames = model.NextOfKinFullnames
                    
                };
                mUTDbcontext.Students.Add(student);
                mUTDbcontext.SaveChanges();
            }
        }

        public List<StudentSport> GetRegisteredStudents(int sportId, string studentId)
        {
            using (mUTDbcontext)
            {
                return mUTDbcontext.StudentSports.Select(x => new StudentSport
                {
                    SportId = x.SportId,
                    StudentId = x.StudentId
                }).ToList();
            }
        }

        public List<StudentModel> GetAllStudents()
        {
            using (mUTDbcontext)
            {
                return mUTDbcontext.Students.Select(x => new StudentModel
                {
                    StudentNumber = x.StudentNumber,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Gender = x.Gender,
                    Email = x.Email,
                    StudyLevel = x.StudyLevel,
                    Qualification = x.Qualification,
                    Accomodation = x.Accomodation,
                    PhoneNumber = x.PhoneNumber,
                    DateCreated = x.DateCreated,
                    DisplayPicture = x.DisplayPicture,
                    MedicalAidCardPic = x.MedicalAidCardPic,
                    NextOfKinPhoneNumber = x.NextOfKinPhoneNumber
                }).ToList();
            }
        }

        public StudentSport RegisterSport(StudentSportModel model)
        {
            using (mUTDbcontext)
            {
                var ss = new StudentSport
                {
                    SportId = model.SportId,
                    StudentId = model.StudentId,
                    DateEnrolled = DateTime.Now
                };

                mUTDbcontext.StudentSports.Add(ss);
                if (mUTDbcontext.SaveChanges() == 1)
                {
                    return ss;
                }
                else
                    return new StudentSport();
            }
            
        }
        public string DeregisterSport(StudentSportModel studentSport)
        {
            return null;
        }
        public List<UpComingEventsModel> GetAllUpcomingEvents()
        {
            using (mUTDbcontext)
            {
                return mUTDbcontext.UpComingEvents.Select(x => new UpComingEventsModel
                {
                    Id = x.Id,
                    Venue = x.Venue,
                    DateClosed = x.DateClosed,
                    DateCreated = x.DateCreated,
                    DateModified = x.DateModified,
                    Descriptions = x.Descriptions, 
                    EndingDate = x.EndingDate,
                    EventPicture = x.EventPicture,
                    StartingDate = x.StartingDate
                }).ToList();
            }
        }

        public StudentModel GetStudentById(string username)
        {
            using (mUTDbcontext)
            {
                return mUTDbcontext.Students
                    .Where(x => x.Email == username)
                    .Select(b => new StudentModel
                    {
                        Id = b.Id,
                        StudentNumber = b.StudentNumber,
                        FirstName = b.FirstName,
                        LastName = b.LastName,
                        Gender = b.Gender,
                        Email = b.Email,
                        StudyLevel = b.StudyLevel,
                        Qualification = b.Qualification,
                        DisplayPicture = b.DisplayPicture,
                        MedicalAidCardPic = b.MedicalAidCardPic,
                        Accomodation = b.Accomodation,
                        PhoneNumber = b.PhoneNumber,
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

        public bool StudentExists(string username)
        {
            using (mUTDbcontext)
            {
                var student = mUTDbcontext.Students.Find(username);

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
                    student.Accomodation = studentModel.Accomodation;
                    student.PhoneNumber = studentModel.PhoneNumber;
                    student.NextOfKinFullnames = studentModel.NextOfKinFullnames;
                    student.NextOfKinPhoneNumber = studentModel.NextOfKinPhoneNumber;
                    student.HasMedicalAid = studentModel.HasMedicalAid;
                    student.MedicalAidNumber = studentModel.MedicalAidNumber;
                    student.DisplayPicture = studentModel.DisplayPicture;
                    student.MedicalAidCardPic = studentModel.MedicalAidCardPic;

                    mUTDbcontext.Students.Update(student);
                    if (mUTDbcontext.SaveChanges() == 1)
                    {
                        return studentModel;
                    }
                    return null;
                }
                else
                {
                    return new StudentModel();
                }
            }
        }

    }
}
