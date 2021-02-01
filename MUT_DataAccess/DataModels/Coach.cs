using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_DataAccess.DataModels
{
    public class Coach
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
