using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_DataAccess.DataModels
{
    public class TeamNotifications
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public byte[] Attachment { get; set; }
       
    }
}
