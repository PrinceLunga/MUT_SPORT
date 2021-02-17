﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_DataAccess.DataModels
{
    public class Sport
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<StudentSport> studentSports { get; set; }
        public IEnumerable<Team> Teams { get; set; }
    }
}
