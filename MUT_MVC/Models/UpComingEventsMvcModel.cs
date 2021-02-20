﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MUT_MVC.Models
{
    [DataContract]
    public class UpComingEventsMvcModel
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
        [DataMember]
        public string Venue { get; set; }
        [DataMember]
        public string StartingDate { get; set; }
        [DataMember]
        public string EndingDate { get; set; }
        [DataMember]
        public int SportId { get; set; }
        [DataMember]
        public string SportName { get; set; }
        [DataMember]
        public string EventPicture { get; set; }
        [DataMember]
        public DateTime DateCreated { get; set; }
        [DataMember]
        public DateTime DateModified { get; set; }
        [DataMember]
        public DateTime DateDeleted { get; set; }
    }
}
