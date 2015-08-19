using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace Web_qwerty_test.Controllers
{
    
    public class HomeController : Controller
    {
        
        private List<ResultOfTest> ListOfResults;

        public ActionResult Index()
        {
            GetResults();
            return View(ListOfResults);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public void GetResults()
        {
            var Path = GetPath();
            if (Path != null && System.IO.File.Exists(Path))
            {
                try
                {
                    var xs = new XmlSerializer(typeof(List<ResultOfTest>));
                    using (var file = System.IO.File.OpenRead(Path))
                    {
                        ListOfResults = (List<ResultOfTest>)xs.Deserialize(file);
                        file.Close();
                    }
                }
                catch
                {
                    ListOfResults = new List<ResultOfTest>();
                }
            }
            else
            {
                ListOfResults = new List<ResultOfTest>();
            }
        }
        public string GetPath()
        {
            if(User == null)
            {
                return null;
            }
            var name = User.Identity.Name;
            return Server.MapPath("~\\App_Data\\" + name + ".test");
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            file.SaveAs(GetPath());
            GetResults();
            return View("Index",ListOfResults);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View(ListOfResults);
        }
    }
}