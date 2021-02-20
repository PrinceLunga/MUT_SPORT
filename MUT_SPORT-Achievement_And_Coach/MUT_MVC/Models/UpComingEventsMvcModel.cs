using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MUT_MVC.Models
{
    public class UpComingEventsMvcModel
    {
        [Key]
        public int Id { get; set; }
        public string Descriptions { get; set; }
        public string Venue { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public int SportId { get; set; }
        public byte[] EventPicture { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateClosed { get; set; }
    }
}
