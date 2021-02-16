using MUT_DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_MODELS
{
    public class TeamAchievementModel
    {
        [Key]
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public AchievementModel Achievement { get; set; }
        public TeamModel Team { get; set; }
    }
}
