using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MUT_MVC.Models
{
    public class AchievementMvcModel
    {
        [Key]
        public int Id { get; set; }
        public string AchievementDescription { get; set; }
        public string DateAchieved { get; set; }
    }
}
