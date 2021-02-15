using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_MODELS
{
    public class Achievement
    {
        [Key]
        public int Id { get; set; }
        public string AchievementDescription { get; set; }
        public string DateAchieved { get; set; }
    }
}
