using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using Registration;

namespace WebRegister.Controllers
{
    public class HomeController : Controller
    {
        private Sportsmens sp;
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated==false) return View("AutificatedNULL");
            InitSportsmens();
           // if (System.IO.File.Exists(GetSportsmensName())) return View("NotFile");
            return View(sp);  
        }

        private void InitSportsmens()
        {
            var spName = GetSportsmensName();
            if (spName != null && System.IO.File.Exists(spName))
            {
                var file = System.IO.File.OpenRead(spName);
                var xs = new XmlSerializer(typeof(Sportsmens));
                sp = (Sportsmens) xs.Deserialize(file);
                file.Close();
            }
            else
            {
                sp = new Sportsmens();
            }
        }
        
        public ActionResult Upload(HttpPostedFileBase file)
        {
            file.SaveAs(GetSportsmensName());
            InitSportsmens();
            Index();
            return View("Index");
        }
        private string GetSportsmensName()
        {
            var name = User.Identity.Name;
            if (User.Identity.IsAuthenticated==false) return null;
            return Server.MapPath("~\\App_Data\\" + name + ".sportsmens");
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
