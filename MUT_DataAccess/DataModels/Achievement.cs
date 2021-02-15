using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_DataAccess.DataModels
{
    public class Achievement
    {
        [Key]
        public int Id { get; set; }
        public string AchievementDescription { get; set; }
        public string DateAchieved { get; set; }
        public int AchievementId { get; set; }
        public IEnumerable<PlayerAchievement> PlayerAchievement { get; set; }
        public IEnumerable<TeamAchievement> TeamAchievements { get; set; }
    }
}
