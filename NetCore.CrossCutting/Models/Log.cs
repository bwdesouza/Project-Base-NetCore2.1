using System;

namespace NetCore.CrossCutting.Models
{
    public class Log
    {
        public DateTime DataLog { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}
