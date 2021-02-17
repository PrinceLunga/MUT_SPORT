using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_MODELS
{
    public class GameResultModel
    {
        [Key]
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string PointsForAwayTeam { get; set; }
        public string PointForHomeTeam { get; set; }
        public string IsHomeWin { get; set; }
        public IEnumerable<TeamModel> Teams { get; set; }
    }
}
