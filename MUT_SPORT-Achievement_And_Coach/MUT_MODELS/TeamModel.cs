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
        public string CreatedBy { get; set; }
        public IEnumerable<TrainingScheduleModel> TrainingSchedule { get; set; }
        public int SportId { get; set; }
        public SportModel Sport { get; set; }
    }
}
