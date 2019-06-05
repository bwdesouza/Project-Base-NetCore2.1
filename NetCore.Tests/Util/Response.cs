using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Tests.Util
{
    public class Response
    {
        public bool success { get; set; }
        public List<Notification> errors { get; set; }
    }
}
