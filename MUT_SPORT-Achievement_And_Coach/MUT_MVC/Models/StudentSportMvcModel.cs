using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MUT_MVC.Models
{
    public class StudentSportMvcModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateEnrolled { get; set; }
        public DateTime DateDelete { get; set; }
        public DateTime DateModified { get; set; }
        public string StudentId { get; set; }
        public int SportId { get; set; }
    }
}
