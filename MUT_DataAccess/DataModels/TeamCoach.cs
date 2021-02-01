using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_DataAccess.DataModels
{
    public class TeamCoach
    {
        [Key]
        public int Id { get; set; }
        public DateTime AssignedDate { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public int CoachId { get; set; }
        public virtual Coach Coaches { get; set; }
    }
}
