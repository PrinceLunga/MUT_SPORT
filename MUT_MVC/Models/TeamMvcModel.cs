﻿using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MUT_MVC.Models
{
    public class TeamMvcModel
    {
        [Key]
        public int Id { get; set; }
        public string TeamName { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public IEnumerable<TrainingScheduleModel> TrainingSchedule { get; set; }
        public int SportId { get; set; }
        public SportModel Sport { get; set; }
    }
}
