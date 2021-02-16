using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_DataAccess.DataModels
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string TeamName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateDeleted { get; set; }
        public string ModifiedBy { get; set; }
        public virtual TeamNotifications TeamNotifications { get; set; }
        public virtual PlayerAchievement PlayerAchievement { get; set; }
        public IEnumerable<TeamPlayer> TeamPlayers { get; set; }
        public IEnumerable<TeamAchievement> TeamAchievements { get; set; }
        
    }
}
