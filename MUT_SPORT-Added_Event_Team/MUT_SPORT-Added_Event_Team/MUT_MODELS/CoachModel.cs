using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_MODELS
{
    public class CoachModel
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
