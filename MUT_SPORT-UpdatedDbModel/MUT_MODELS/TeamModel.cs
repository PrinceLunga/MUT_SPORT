using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_MODELS
{
    public class TeamModel
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public int SportId { get; set; }
        public virtual SportModel SportModel { get; set; }
        
    }
}
