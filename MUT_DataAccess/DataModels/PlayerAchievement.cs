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
        public int PlayerId { get; set; }
        public string AchievementDescription { get; set; }
        public bool IsFirstTimeAchievement { get; set; }
        public DateTime DateAwarded { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }
    }
}
