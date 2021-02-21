using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_MODELS
{
    public class PlayerAchievementModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateAwarded { get; set; }
        [Display(Name = "Achievement")]
        public int AchievementId { get; set; }
        public virtual AchievementModel Achievement { get; set; }
        [Display(Name = "Player")]
        public int PlayerId { get; set; }
        public virtual TeamPlayerModel Player { get; set; }
    }
}
