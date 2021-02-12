using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_MODELS
{
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }
        public string Fullnames { get; set; }
        public string StudentNumber { get; set; }
        public string Accomodation { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string NextOfKinFullnames { get; set; }
        public string NextOfKinPhoneNumber { get; set; }
        public Boolean HasMedicalAid { get; set; }
        public string MedicalAidNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public byte[] MedicalAidCard { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateDeleted { get; set; }
        public int SportId { get; set; }
        public IEnumerable<SportModel> sports { get; set; }
    }
}
