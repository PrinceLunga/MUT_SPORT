using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_MODELS
{
    public class TrainingScheduleModel
    {
        [Key]
        public int Id { get; set; }
        public string Venue { get; set; }
        public string StartTime { get; set; }
        public string FinishTime { get; set; }
        public DateTime DateOfSession { get; set; }

    }
}
