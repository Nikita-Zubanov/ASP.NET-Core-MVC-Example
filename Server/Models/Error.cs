using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Server.Models
{
    [NotMapped]
    public class Error
    {
        public HttpStatusCode StatusCode { get; private set; }
        public string Message { get; private set; }

        public Error(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
