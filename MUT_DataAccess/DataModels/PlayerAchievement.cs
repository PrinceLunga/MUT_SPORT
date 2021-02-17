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
        public DateTime DateAwarded { get; set; }
        public int AchievementId { get; set; }
        public virtual Achievement Achievement { get; set; }
        public int PlayerId { get; set; }
        public virtual TeamPlayer Player { get; set; }
    }
}
