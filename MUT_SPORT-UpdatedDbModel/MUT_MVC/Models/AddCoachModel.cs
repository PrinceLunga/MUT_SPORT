using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MUT_MVC.Models
{
    public class AddCoachModel
    {
        [Key]
        public int Id { get; set; }
        public string Fullnames { get; set; }
        public string EmailAddress { get; set; }
        public string SportName { get; set; }
        public string PhoneNumber { get; set; }
        public string TeamName { get; set; }
    }
}
