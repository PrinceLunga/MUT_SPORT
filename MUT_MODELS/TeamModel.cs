using MUT_DataAccess.DataModels;
using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_MODELS
{
    public class TeamModel
    {
        [Key]
        public int Id { get; set; }
        public string TeamName { get; set; }
        public DateTime DateCreated { get; set; }
        public string ModifiedBy { get; set; }
        public virtual IEnumerable<TeamNotificationsModel> TeamNotifications { get; set; }
        public virtual IEnumerable<PlayerAchievementModel> PlayerAchievements { get; set; }
        public virtual IEnumerable<TeamPlayerModel> TeamPlayers { get; set; }
    }
}
