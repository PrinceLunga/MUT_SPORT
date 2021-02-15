using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MUT_MVC.Models
{
    public class TrainingMvcModels
    {
        [Key]
        public int Id { get; set; }

        public int sportId { get; set; }

        public string Venue { get; set; }

        [DisplayName("Starting Time")]
        public string StartTime { get; set; }

        [DisplayName("Finishing Time")]
        public string FinishTime { get; set; }

        [DisplayName("Date")]
        public DateTime DateOfSession { get; set; }
    }
}
