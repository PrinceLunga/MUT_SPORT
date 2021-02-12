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
        public StudentSportService(MUTDbContext _mUTDbContext)
        {
            this.mUTDbContext = _mUTDbContext;
        }
        public List<StudentSportModel> GetStudentSports()
        {
            using (mUTDbContext)
            {
                return mUTDbContext.StudentSports.Select(x => new StudentSportModel
                {
                    DateEnrolled = x.DateEnrolled,
                    DateDeleted = x.DateDelete,
                    DateModified = x.DateModified
                }).ToList();
            }
        }

        public List<StudentSportModel> GetStudentSports(string studentNumber, string Fullnames)
        {
            using (mUTDbContext)
            {
                return mUTDbContext.StudentSports.Where( b => b.Students.StudentNumber.Equals(studentNumber) 
                || b.Students.Fullnames.Equals(Fullnames))
                    .Select(x => new StudentSportModel
                {
                    DateEnrolled = x.DateEnrolled,
                    DateDeleted = x.DateDelete,
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
                    DateEnrolled = studentSportModel.DateEnrolled,
                    DateModified = studentSportModel.DateModified,
                    Students = new Student
                    {
                       // Id = studentSportModel.Students.Id,
                        Accomodation = studentSportModel.Students.Accomodation,
                        DateCreated = studentSportModel.Students.DateCreated,
                        DateModified = new DateTime(),
                        DateDeleted = new DateTime(),
                        Fullnames = studentSportModel.Students.Fullnames,
                        HasMedicalAid = studentSportModel.Students.HasMedicalAid,
                        MedicalAidCard = studentSportModel.Students.MedicalAidCard,
                        MedicalAidNumber = studentSportModel.Students.MedicalAidNumber,
                        NextOfKinFullnames = studentSportModel.Students.NextOfKinFullnames,
                        NextOfKinPhoneNumber = studentSportModel.Students.NextOfKinPhoneNumber,
                        PhoneNumber = studentSportModel.Students.PhoneNumber,
                    },
                };
                mUTDbContext.StudentSports.Add(studentSport);
                mUTDbContext.SaveChanges();
            }
        }
    }
}
