using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_DataAccess.DataModels
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string TeamName { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public int TeamNotificationId { get; set; }
        public IEnumerable<TeamNotifications> Teams { get; set; }
    }
}
