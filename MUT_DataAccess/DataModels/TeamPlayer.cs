using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_DataAccess.DataModels
{
    public class TeamPlayer
    {
        [Key]
        public int Id { get; set; }
        public bool IsCaptain { get; set; }
        public bool IsViceCaptain { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime LastDate { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public IEnumerable<PlayerAchievement> PlayerAchievements { get; set; }
    }
}
