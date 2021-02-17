using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_MODELS
{
    public class SportModel
    {
       [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public IEnumerable<StudentModel> Students { get; set; }
        public IEnumerable<StudentSportModel> studentSports { get; set; }
        public IEnumerable<TeamModel> Teams { get; set; }
    }
}
