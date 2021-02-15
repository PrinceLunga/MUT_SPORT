using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_MVC.Models
{
    public class StudentRegisterSportTeamsModel
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public bool IsRegistered { get; set; }
    }
}
