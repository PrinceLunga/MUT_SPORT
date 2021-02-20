using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MUT_MVC.Models
{
    public class EventMvcModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Venue { get; set; }
        public string EventDate { get; set; }
        public string StartingTime { get; set; }
        public string EndingTime { get; set; }
    }
}
