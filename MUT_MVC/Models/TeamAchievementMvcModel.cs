using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MUT_MVC.Models
{
    public class TeamAchievementMvcModel
    {
        [Key]
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int AchievementId { get; set; }
        public DateTime DateAwarded { get; set; }
    }
}
