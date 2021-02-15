﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_DataAccess.DataModels
{
    public class Residence
    {
        [Key]
        public int ResId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool isInMainCamp { get; set; }
    }
}
