using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUT_MODELS
{
    public class NotoficationModel
    {
        [Key]
        public int Id { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
        public bool IsBroadCastMessage { get; set; }
        public byte[] Attachments { get; set; }
    }
}
