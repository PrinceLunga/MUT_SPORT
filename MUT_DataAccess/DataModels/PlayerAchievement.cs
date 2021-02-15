using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_DataAccess.DataModels
{
    public class PlayerAchievement
    {
        [Key]
        public int Id { get; set; }
        public string PlayerId { get; set; }
        public int AchievementId { get; set; }
        public DateTime DateAwarded { get; set; }
    }
}
