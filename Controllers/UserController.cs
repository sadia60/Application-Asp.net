using System;
//for json
using Newtonsoft.Json;
//for tcp connnection
using System.IO;
using System.Text;
using System.Net.Sockets;
using ColdWhereApplication.Models;
using System.Web.Mvc;
using System.Collections.Generic;

namespace ColdWhereApplication.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        // POST: User
        [HttpPost]
        public ActionResult Login(string uname, string password, string role)
        {
            //*****************Validation



            if (ModelState.IsValid == false)
            {
                 return View();
            }
            
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Serialization

            string send="";
            if (role == "login_user") {
                //response
                //{ message_type = "login_user","email":"syedasadiatariq60@gmail.com","password":"Password55"}
                //{ message_type = "login_user", email ="hello", password = "123" }
                User user = new User();
                //set 
                user.email = uname;
                //   user.email = email;
                user.password = password;
                user.message_type = role;
                send = JsonConvert.SerializeObject(user);
            }

            else if (role == "get_all_companies") {
                companyuser user = new companyuser();
                //set 
                user.email = uname;
                
                user.message_type = role;


                send = JsonConvert.SerializeObject(user);

                TempData["send"] = send;
                return RedirectToAction("Index", "Company");
                //send = "Request: { message_type :get_all_companies, email :hello}";
            }


            //***************** TCP Connection 
            char[] response = new char[5000];
            try
            {
                TcpClient tcpclnt = new TcpClient();
                Console.WriteLine("Connecting.....");
                tcpclnt.Connect("35.161.234.96", 9991);
                
                //user.email =" message_type = "+"login_user"+","+ "email:" +email+",";
                //user.password = "password:"+Password;
                // Request: { message_type : "get_all_companies", email : "hello" };

                Stream stm = tcpclnt.GetStream();
                ASCIIEncoding asen = new ASCIIEncoding();
                //convert to bytes
                byte[] ba = asen.GetBytes(send);

                //write to stream
                stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[5000];
                //read from stream
                int k = stm.Read(bb, 0, 5000);

                for (int i = 0; i < k; i++)
                    response[i] = Convert.ToChar(bb[i]);

                tcpclnt.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }


            //*****************JSON RESPONSE
            string Receive = new string(response);
            String rawjson = Receive;
            string responsecode = "";
            //******************************************************Deserialization
            /*
            if (role =="login_user")
            {
                // Response object with generic details
                ResponseObject<Details> res = JsonConvert.DeserializeObject<ResponseObject<Details>>(rawjson);
                string usertype = res.message_type;
                responsecode = res.response_code;
                string status = res.status;
                Details details = res.details;
            }

            else 
            */
            if (role == "get_all_companies")
            {
                //    RootObject<DetialsofCompany> res = JsonConvert.DeserializeObject<RootObject<DetialsofCompany>>(rawjson);

                IList<companydetails> companydetailsList = new List<companydetails>();

                RootObject<companydetails> res = JsonConvert.DeserializeObject<RootObject<companydetails>>(rawjson);
                //   List<T companydetails> listCustomers = new List<companydetails>();
                string usertype = res.message_type;
                responsecode = res.response_code;
                string status = res.status;
                companydetailsList = res.companydetails;

                RootObject<companydetails> root=new RootObject<companydetails>(res.message_type,res.status,res.response_code,companydetailsList);

                foreach (companydetails value in companydetailsList)
                {
                    Console.WriteLine(value.email);
                    Console.WriteLine(value.name);

                }


                TempData["companydetailsList"] = companydetailsList;
                //companydetailsList = JsonConvert.DeserializeObject <List<companydetails>>(res.companydetails.ToString());//res.companydetails;


                //   listCustomers= res.companydetails;
                //  companydetails company= res.companydetails;
                //res.DetialsofCompany;
                //res.DetialsofCompany;
                //DetialsofCompany dispalydetails= JsonConvert.DeserializeObject(res.details);
            }

            TempData["message"] = null; 
            //******************************************************UNSUCESSFUL responsecode
            if (responsecode != "1100")
            {
                TempData["message"] = "Invalid Credentials";
                return View();
            }
            if (responsecode == null)
            {
                TempData["message"] = "Server Error";
            }

            // User Details
            // *********************************************  On Successful code  view details
            Details rcvdetails = new Details();
            //            rcvdetails = res.details;


            if (role == "get_all_companies")

                return RedirectToAction("Index", "Details");

            //*********************************************   Store data in session            
            Session["name"] = rcvdetails.name;
            Session["role"] = rcvdetails.role;
            Session["email"] = rcvdetails.email;
            //return RedirectToAction("Index","Home");
      
            return RedirectToAction("Index", "Home");
        }
    }

}


            //"{\"message_type\":\"get_all_companies\",\"status\":\"Success\",\"response_code\":\"1100\",
            // \"details\":[{\"name\":\"Love Company\",\"logo\":\"avatar-5.png\",\
            //"address\":\"Oregon\",\"email\":\"love\",\"portal_main_color\":\"#134f5c\",

            //\"portal_secondary_color\":\"#0c343d\",\"is_new_password\":false,\"phone_number\"
            //:\"9540940\"},{\"name\":\"Naya Kam\",\"logo\":\"avatar-1.png\",\"address\":\
            //"California, United States\",\"email\":\"company1@gmail.com\",\"portal_main_color\"" +
              //  ":\"#990000\",\"portal_secondary_color\":\"#660000\",\"is_new_password\":false," +
               // "\"phone_number\":\"3445"
