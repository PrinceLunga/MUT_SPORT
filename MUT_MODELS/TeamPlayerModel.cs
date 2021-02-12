using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_MODELS
{
    public class TeamPlayerModel
    {
        [Key]
        public int Id { get; set; }
        public bool IsCaptain { get; set; }
        public bool IsViceCaptain { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime LastDate { get; set; }
        public int TeamId { get; set; }
        public virtual TeamModel Team { get; set; }
        public int StudentId { get; set; }
        public virtual StudentModel Student { get; set; }
    }
}
