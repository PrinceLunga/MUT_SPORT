using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_DataAccess.DataModels
{
    public class Residence
    {
        [Key]
        public int Id { get; set; }
        public string ResName { get; set; }
        public string Address { get; set; }


    }
}
