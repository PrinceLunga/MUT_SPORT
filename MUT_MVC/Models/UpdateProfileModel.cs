using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MUT_MVC.Models
{
    public class UpdateProfileModel
    {

        [Key]
        public int Id { get; set; } 
        public string PhoneNumber { get; set; }
        public string Accomodation { get; set; }
        public string NextOfKinFullnames { get; set; }
        public string NextOfKinPhoneNumber { get; set; }
        public Boolean HasMedicalAid { get; set; }
        public string MedicalAidNumber { get; set; }
        public string DisplayPicture { get; set; }
        public string MedicalAidCardPic { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateDeleted { get; set; }
    }
}
