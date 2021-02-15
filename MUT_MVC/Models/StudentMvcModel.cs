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
        [Required]
        public string StudentNumber { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Qualification { get; set; }

        [Required]
        public string StudyLevel { get; set; }

        [Required]
        public string Accomodation { get; set; }
        
        public string NextOfKinFullnames { get; set; }

        [Required]
        public string NextOfKinPhoneNumber { get; set; }
        
        public Boolean HasMedicalAid { get; set; }
        
        public string MedicalAidNumber { get; set; }
        
        public byte[] DisplayPicture { get; set; }
        
        public byte[] MedicalAidCardPic { get; set; }
        
        public DateTime DateCreated { get; set; }
        
        public DateTime DateModified { get; set; }
        
        public DateTime DateDeleted { get; set; }

        [Required]
        public string Password { get; set; }
        
        [Required]
        public string confirmPassword { get; set; }
    }
}
