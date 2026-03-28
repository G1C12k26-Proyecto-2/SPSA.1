using System;
using System.Collections.Generic;
using System.Text;

namespace AppLogic.Templates
{
    public class EmailMessage
    {
        public string Subject { get; set; }
        public string PlainTextBody { get; set; }
        public string HtmlBody { get; set; }
    }
}