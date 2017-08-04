using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailSubsystem_SendGrid_WebApp_.Models.HelperClasses
{
    public class EmailResponse
    {
        public DateTime DateSent { get; internal set; }
        public string UniqueMessageId { get; internal set; }
    }
}