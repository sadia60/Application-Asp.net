using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ColdWhereApplication.Models
{
    //Response object might have details null at times or deatials
    public class ResponseObject<T>

    {
        public string message_type { get; set; }
        public string status { get; set; }
        public string response_code { get; set; }

        public T details { get; set; }

        public ResponseObject(string message_type, string status, string response_code, T details)
        {
            this.message_type = message_type;
            this.status = status;
            this.response_code = response_code;
            this.details = details;
        }
    }
}