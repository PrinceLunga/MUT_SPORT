using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_DataAccess.DataModels
{
    public class AchievementModel
    {
        [Key]
        public int Id { get; set; }
        public string AchievementDescription { get; set; }
        public string DateAchieved { get; set; }
        public int PlayerAchievementId { get; set; }
        public IEnumerable<PlayerAchievementModel> PlayerAchievement { get; set; }
        public int AchievementId { get; set; }
        public IEnumerable<TeamAchievementModel> TeamAchievements { get; set; }
    }
}
