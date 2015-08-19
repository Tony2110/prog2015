using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using Passport;

namespace WebPassport.Controllers
{
    public class HomeController : Controller
    {
        private PassportData pd;

        public HomeController()
        {
        }

        public ActionResult Index()
        {
            InitPassport();

            return View(pd);
        }

        private void InitPassport()
        {
            var passportName = GetPassportName();
            if (passportName != null && System.IO.File.Exists(passportName))
            {
                var xs = new XmlSerializer(typeof (PassportData));
                var file = System.IO.File.OpenRead(passportName);
                pd = (PassportData) xs.Deserialize(file);
                file.Close();
            }
            else
            {
                pd = new PassportData();
            }
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            


            file.SaveAs(GetPassportName());
            return View("Index");
        }

        private string GetPassportName()
        {
            if (User == null)
                return null;
            var name = User.Identity.Name;
            return Server.MapPath("~\\App_Data\\" + name + ".passport");
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