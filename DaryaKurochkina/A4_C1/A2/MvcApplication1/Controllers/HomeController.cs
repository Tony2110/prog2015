using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using A2;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        private Event sp;
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated == false) return View("NevypolnenVhod");
            InitPocupatel();
            return View(sp);
        }
        private void InitPocupatel()
        {
            var spName = GetName();
            if (spName != null && System.IO.File.Exists(spName))
            {
                var file = System.IO.File.OpenRead(spName);
                var xs = new XmlSerializer(typeof(Event));
                sp = (Event)xs.Deserialize(file);
                file.Close();
            }
            else
            {
                sp = new Event();
            }
        }
        private string GetName()
        {
            var name = User.Identity.Name;
            if (User.Identity.IsAuthenticated == false) return null;
            return Server.MapPath("~\\App_Data\\" + name + ".event");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Upload (HttpPostedFileBase file)
        {
            file.SaveAs(GetName());
            InitPocupatel();
            return View("Index",sp);
        }
    }
}
