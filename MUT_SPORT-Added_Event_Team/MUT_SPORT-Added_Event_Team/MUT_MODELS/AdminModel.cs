using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_MODELS
{
    public class AdminModel
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeNumber { get; set; }
        public string Fullname { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
