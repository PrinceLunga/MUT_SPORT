using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_DataAccess.DataModels
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Qualification { get; set; }
        public string StudyLevel { get; set; }
        public string Accomodation { get; set; }
        public string NextOfKinFullnames { get; set; }
        public string NextOfKinPhoneNumber { get; set; }
        public Boolean HasMedicalAid { get; set; }
        public string MedicalAidNumber { get; set; }
        public byte[] DisplayPicture { get; set; }
        public byte[] MedicalAidCardPic { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateDeleted { get; set; }

        public int StudentSportId { get; set; }
        public IEnumerable<StudentSport> studentSports { get; set; }
    }
}
