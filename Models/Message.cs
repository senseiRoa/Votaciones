using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demokratianweb.Models
{

    public class Message
    {
        public string Clientuniqueid { get; set; }
        public string Type { get; set; }
        public string Payload { get; set; }
        public string Summary { get; set; }
        public string rondaId { get; set; }

        
    }

    public static class MessageType
    {
        public static string success = "success";

        public static string error = "error";

    }
}
