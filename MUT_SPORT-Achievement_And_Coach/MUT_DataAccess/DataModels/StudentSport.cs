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
        public DateTime DateDeleted { get; set; }
        public DateTime DateModified { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; }
    }
}
