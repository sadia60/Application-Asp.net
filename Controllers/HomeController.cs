using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ColdWhereApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            string name=   Session["name"].ToString();
            string role =  Session["role"].ToString();
            string email = Session["email"].ToString();
          

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}