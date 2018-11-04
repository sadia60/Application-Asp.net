using System;
using System.Collections.Generic;
using System.Web.Mvc;
//for json
using Newtonsoft.Json;
//for tcp connnection
using System.IO;
using System.Text;
using System.Net.Sockets;
using ColdWhereApplication.Models;

namespace ColdWhereApplication.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            string send="";
            if (TempData["send"].ToString() != null) { 
            send = TempData["send"].ToString();
            }

            //***************** TCP Connection 
            char[] response = new char[5000];
            try
            {
                TcpClient tcpclnt = new TcpClient();
                Console.WriteLine("Connecting.....");
                tcpclnt.Connect("35.161.234.96", 9991);

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
            string rawjson = new string(response);
           
            string responsecode = "";
            //******************************************************Deserialization
                IList<companydetails> companydetailsList = new List<companydetails>();
                RootObject<companydetails> res = JsonConvert.DeserializeObject<RootObject<companydetails>>(rawjson);
                //   List<T companydetails> listCustomers = new List<companydetails>();
                string usertype = res.message_type;
                responsecode = res.response_code;
                string status = res.status;
                companydetailsList = res.companydetails;

                RootObject<companydetails> root = new RootObject<companydetails>(res.message_type, res.status, res.response_code, companydetailsList);
                foreach (companydetails value in companydetailsList)
                {
                    Console.WriteLine(value.email);
                    Console.WriteLine(value.name);

                Console.WriteLine(value.phone_number);
                Console.WriteLine(value.address);
                

            }

            //TempData["companydetailsList"] = companydetailsList;
            return View(companydetailsList);
            
        }
    }
    }