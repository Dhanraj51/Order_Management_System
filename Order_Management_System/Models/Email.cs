using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Order_Management_System.Models
{
    public partial class Email
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}