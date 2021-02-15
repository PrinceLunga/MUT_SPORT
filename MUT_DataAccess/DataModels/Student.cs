﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_DataAccess.DataModels
{
    public class Student
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
        public byte[] MedicalAidCard { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateDeleted { get; set; }
        public IEnumerable<StudentSport> StudentSports { get; set; }
        public int TeamPlayerId { get; set; }
        public IEnumerable<TeamPlayer> TeamPlayer  { get; set; }
    }
}
