using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_DataAccess.DataModels
{
    public class UpComingEvent
    {
        [Key]
        public int Id { get; set; }
        public string Descriptions { get; set; }
        public string Venue { get; set; }
        public DateTime StartingTime  { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateClosed { get; set; }

    }
}
