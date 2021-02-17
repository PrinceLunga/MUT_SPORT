using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_MODELS
{
    public class StudentSportModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateEnrolled { get; set; }
        public DateTime DateDeleted { get; set; }
        public DateTime DateModified { get; set; }
        public int StudentId { get; set; }
        public virtual StudentModel StudentModel { get; set; }
        public int SportId { get; set; }
        public virtual SportModel SportModel { get; set; }

    }
}
