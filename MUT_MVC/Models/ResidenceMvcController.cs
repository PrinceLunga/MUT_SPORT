using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MUT_MVC.Models
{
    public class ResidenceMvcController
    {
        [Key]
        public int ResId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool isInMainCamp { get; set; }
    }
}
