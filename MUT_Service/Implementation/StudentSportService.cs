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
    public class StudentSportService : IStudentSportService
    {
        private readonly MUTDbContext mUTDbContext;
        private readonly ISportService sportService;
        public StudentSportService(MUTDbContext _mUTDbContext, ISportService sportService)
        {
            this.mUTDbContext = _mUTDbContext;
        }
        public List<StudentSportModel> GetStudentSports()
        {
            using (mUTDbContext)
            {
                return mUTDbContext.StudentSports.Select(x => new StudentSportModel
                {
                    SportId = x.SportId,
                    StudentId = x.StudentId,
                    DateEnrolled = x.DateEnrolled,
                    DateModified = x.DateModified,
                }).ToList();
            }
        }

        public List<StudentSportModel> GetStudentSportsByEmail(string email)
        {
            using (mUTDbContext)
            {
                var student = mUTDbContext.Students.Where(x => x.Email == email).SingleOrDefault();
                return mUTDbContext.StudentSports.Where( b => b.StudentId.Equals(student.Email)).Select(x => new StudentSportModel
                {
                    SportId = x.SportId,
                    StudentId = x.StudentId,
                    DateEnrolled = x.DateEnrolled,
                    DateModified = x.DateModified
                }).ToList();
            }
        }


        public void RegisterStudentToSport(StudentSportModel studentSportModel)
        {
            using(mUTDbContext)
            {
                var studentSport = new StudentSport
                {
                    SportId = studentSportModel.SportId,
                    DateEnrolled = studentSportModel.DateEnrolled,
                    DateModified = studentSportModel.DateModified,
                    //Student = new Student
                    //{
                    //    StudentNumber = studentSportModel.Students.StudentNumber,
                    //    FirstName = studentSportModel.Students.FirstName,
                    //    LastName = studentSportModel.Students.LastName,
                    //    Gender = studentSportModel.Students.Gender,
                    //    Email = studentSportModel.Students.Email,
                    //    StudyLevel = studentSportModel.Students.StudyLevel,
                    //    Qualification = studentSportModel.Students.Qualification,
                    //    Accomodation = studentSportModel.Students.Accomodation,
                    //    PhoneNumber = studentSportModel.Students.PhoneNumber,
                    //    DateCreated = studentSportModel.Students.DateCreated
                    //},
                    //Sports = mUTDbContext.Sports.Where(x => x.Id == studentSportModel.Id).Take(1),
                    StudentId = studentSportModel.StudentId
                    

                };
                mUTDbContext.StudentSports.Add(studentSport);
                mUTDbContext.SaveChanges();
            }
        }

        public void DeregisterSport(int sportId)
        {
            using (mUTDbContext)
            {
                var sport = mUTDbContext.StudentSports.Where(x => x.SportId == sportId).SingleOrDefault();

                if (sportId != 0)
                {
                    mUTDbContext.StudentSports.Remove(sport);
                    mUTDbContext.SaveChanges();
                }
            }
        }
    }
}
