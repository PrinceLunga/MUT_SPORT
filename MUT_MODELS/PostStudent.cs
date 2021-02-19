﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace MUT_MODELS
{
    [DataContract]
    public class PostStudent
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string StudentNumber { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Qualification { get; set; }
        [DataMember]
        public string StudyLevel { get; set; }
        [DataMember]
        public string Accomodation { get; set; }
        [DataMember]
        public string NextOfKinFullnames { get; set; }
        [DataMember]
        public string NextOfKinPhoneNumber { get; set; }
        [DataMember]
        public Boolean HasMedicalAid { get; set; }
        [DataMember]
        public string MedicalAidNumber { get; set; }
        [DataType(DataType.Password)]
        [DataMember]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [DataMember]
        public string ConfirmPassword { get; set; }
        [DataMember]
        public string DisplayPicture { get; set; }
        [DataMember]
        public string MedicalAidCardPic { get; set; }
        [DataMember]
        public DateTime DateCreated { get; set; }
        [DataMember]
        public DateTime DateModified { get; set; }
        [DataMember]
        public DateTime DateDeleted { get; set; }
    }
}
