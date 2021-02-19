using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_DataAccess.DataModels
{
    public class StudentSport
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateEnrolled { get; set; }
        public DateTime DateDelete { get; set; }
        public DateTime DateModified { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int SportId { get; set; }
        public IEnumerable<Sport> Sports { get; set; }
    }
}
