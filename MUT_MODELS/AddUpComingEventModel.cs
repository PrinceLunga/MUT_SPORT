using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace MUT_MODELS
{
    [DataContract]
    public class AddUpComingEventModel
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
        public string SportId { get; set; }
        [DataMember]
        public string SportName { get; set; }
        [DataMember]
        public IFormFile EventPicture { get; set; }
        [DataMember]
        public string DateCreated { get; set; }
        [DataMember]
        public string DateModified { get; set; }
        [DataMember]
        public string DateClosed { get; set; }
    }
}
