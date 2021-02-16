using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MUT_DataAccess.DataModels
{
    public class Admin
    {
        [Key]
        public int Id {get;set ;}
        public string EmployeeNumber { get; set; }
        public string Fullname { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
