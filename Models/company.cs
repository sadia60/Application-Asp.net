using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Request class for the company users
namespace ColdWhereApplication.Models
{
    public class companydetails
    {
        public string name { get; set; }
        public string logo { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string portal_main_color { get; set; }
        public string portal_secondary_color { get; set; }
        public string is_new_password { get; set; }
        public string phone_number { get; set; }

    }

    //public class DetialsofCompany
    //{
    //    List<companydetails> listCustomers = new List<companydetails>();
    //}

}
    //Receive	"{\"message_type\":\"get_all_companies\",\"status\":\"Success\",\"response_code\"
    //:\"1100\",\

    //"details\":[{\"name\":\"Love Company\",\"logo\":\"avatar-5.png\",\"address\":\"Oregon\",
    //\"email\":\"love\",\"portal_main_color\":\"#134f5c\",\"portal_secondary_color\":\"#0c343d\",\"is_new_password
    //\":false,\"phone_number\":\"9540940\"},{\"name\":\"Naya Kam\",\"logo\":\"avatar-1.png\",\"address\":\
    //"California, United States\",\"email\":\"company1@gmail.com\",\"portal_main_color\":\"#990000\",\"portal_
    //secondary_color\":\"#660000\",\"is_new_password\":false,\"phone_number\":\"34454\"},{\"name\":\"ColdWhere  
    //- Brutus\",\"logo\":\"avatar-7.png\",\"address\":\"10800 Lyndale AVE S, Suite 75\",\"email\":
    //\"ian@coldwhere.com\",\"portal_main_color\":\"#000000\",\"is_new_password\":true,\"phone_number\":
    //\"6122490496\"},{\"name\":\"Michael Cutler\",\"logo\":\"avatar-7.png\",\"address\":\"PA\",\"email\":
    //\"transportation@michaelcutlerco.com \",\"is_new_password\":false,\"phone_number\":\"800-977-7275 Ext 223 \"
    //},{\"name\":\"Company Logo Path\",\"logo\":\"avatar-1.png\",\"address\":\"Oregon\",\"email\":\"companylogoPath@gmail.com\",\"portal_main_color\":\"#e69138\",\"portal_secondary_color\":\"#b45f06\",\"is_new_password\":false,\"phone_number\":\"4597956\"},{\"name\":\"Company Logo Path1\",\"address\":\"California, United States\",\"email\":\"companylogoPath1@gmail.com\",\"portal_main_color\":\"#a64d79\",\"portal_secondary_color\":\"#4c1130\",\"is_new_password\":false,\"phone_number\":\"454058\"},{\"name\":\"Testing Logo\",\"logo\":\"avatar-1.png\",\"address\":\"California, United States\",\"email\":\"companylogoPathTesting@gmail.com\",\"portal_main_color\":\"#741b47\",\"portal_secondary_color\":\"#4c1130\",\"is_new_password\":false,\"phone_number\":\"5745949\"},{\"name\":\"new company\",\"address\":\"California, United States\",\"email\":\"companylogoPath101@gmail.com\",\"portal_main_color\":\"#20124d\",\"portal_secondary_color\":\"#0c343d\",\"is_new_password\":false,\"phone_number\":\"384038\"},{\"name\":\"kurt White\",\"logo\":\"avatar-7.png\",\"address\":\"13986 Valley Ridge Omaha NB 68138\",\"email\":\"kurt.white@midlandscarrier.com\",\"portal_main_color\":\"#bf9000\",\"portal_secondary_color\":\"#7f6000\",\"is_new_password\":false,\"phone_number\":\"47979795\"},{\"name\":\"Bloxom Company\",\"logo\":\"avatar-7.png\",\"email\":\"brianb@fcbloxom.com\",\"is_new_password\":true,
    //\"phone_number\":\"206-795-3075\"},{\"logo\":\"avatar-7.png\",\"email\":\"comany1@gmail.com\",\"is_new_password\":true}]}"
