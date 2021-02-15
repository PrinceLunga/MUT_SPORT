using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_DataAccess.DataModels
{
    public class TeamAchievement
    {
        [Key]
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int AchievementId { get; set; }
        public DateTime DateAwarded { get; set; }
    }
}
