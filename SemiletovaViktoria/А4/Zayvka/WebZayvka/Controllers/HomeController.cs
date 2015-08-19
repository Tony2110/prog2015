using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using Zayvka;

namespace WebZayvka.Controllers
{
    public class HomeController : Controller
    {
        private Zakaz sp;
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated == false) return View("Nointer");
            InitPocupatel();
            return View(sp);
        }

        private void InitPocupatel()
        {
            var spName = GetName();
            if (spName != null && System.IO.File.Exists(spName))
            {
                var file = System.IO.File.OpenRead(spName);
                var xs = new XmlSerializer(typeof(Zakaz));
                sp = (Zakaz)xs.Deserialize(file);
                file.Close();
            }
            else
            {
                sp = new Zakaz();
            }
        }

        public ActionResult Upload(HttpPostedFileBase file)
        {
            file.SaveAs(GetName());
            InitPocupatel();
            Index();
            return View("Index");
        }
        private string GetName()
        {
            var name = User.Identity.Name;
            if (User.Identity.IsAuthenticated == false) return null;
            return Server.MapPath("~\\App_Data\\" + name + ".zakaz");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Страница описания приложения.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Страница контактов.";

            return View();
        }
    }
}
