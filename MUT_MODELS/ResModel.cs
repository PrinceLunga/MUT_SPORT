using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_MODELS
{
    public class ResModel
    {
        [Key]
        public int ResId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool isInMainCamp { get; set; }
    }
}
