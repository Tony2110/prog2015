using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using Recipe;
namespace WebRecipe.Controllers
{
    public class HomeController : Controller
    {
        private ProductData pd;
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated == false) return View("AutificatedNULL");
            Initfoods();
            return View(pd);
        }

        private void Initfoods()
        {
            var pdName = GetProductName();
            if (pdName != null && System.IO.File.Exists(pdName))
            {
                var file = System.IO.File.OpenRead(pdName);
                var xs = new XmlSerializer(typeof(ProductData));
                pd = (ProductData)xs.Deserialize(file);
                file.Close();
            }
            else
            {
                pd = new ProductData();
            }
        }

        public ActionResult Upload(HttpPostedFileBase file)
        {
            file.SaveAs(GetProductName());
            Initfoods();
            Index();
            return View("Index");
        }
        private string GetProductName()
        {
            var name = User.Identity.Name;
            if (User.Identity.IsAuthenticated == false) return null;
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
