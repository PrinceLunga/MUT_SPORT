﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_DataAccess.DataModels
{
    public class StudentSport
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateEnrolled { get; set; }
        public DateTime DateDelete { get; set; }
        public DateTime DateModified { get; set; }
        public Student Students { get; set; }
        public Sport Sports { get; set; }
    }
}
