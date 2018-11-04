using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ColdWhereApplication.Models
{
    public class RootObject<T>
    {
        //Response object might have details null at times or companydetails
        public string message_type { get; set; }
        public string status { get; set; }
        public string response_code { get; set; }

        [JsonProperty("details")]
        public IList<T> companydetails { get; set; }

        public RootObject(string message_type, string status, string response_code, IList<T> DetialsofCompany)
            {
                this.message_type = message_type;
                this.status = status;
                this.response_code = response_code;
           
                this.companydetails = DetialsofCompany;
            

        }
        }
    }
