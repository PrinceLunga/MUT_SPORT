using Microsoft.AspNetCore.Http;
using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MUT_MVC.Models
{
    public class StudentMvcModel
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
        public IFormFile DisplayPicture { get; set; }
        public IFormFile MedicalAidCardPic { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateDeleted { get; set; }
    }
}
