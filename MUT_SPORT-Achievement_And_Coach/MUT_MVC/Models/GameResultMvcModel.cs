using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MUT_MVC.Models
{
    public class GameResultMvcModel
    {
        [Key]
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string HomeTeam { get; set; }
        public int SportId { get; set; }
        public string AwayTeam { get; set; }
        public string PointsForAwayTeam { get; set; }
        public string PointForHomeTeam { get; set; }
        public string IsHomeWin { get; set; }
    }
}
