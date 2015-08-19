using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using Task_Scheduler;

namespace WebScheduler.Controllers
{
    public class HomeController : Controller
    {
        private TaskSchedulerData pd;
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated == false) return View("AutificatedNULL");
            InitScheduler();
            return View(pd);
        }

        private void InitScheduler()
        {
            var SchedulerName = GetPath();
            if (SchedulerName != null && System.IO.File.Exists(SchedulerName))
            {
                var xs = new XmlSerializer(typeof(TaskSchedulerData));
                var file = System.IO.File.OpenRead(SchedulerName);
                pd = (TaskSchedulerData)xs.Deserialize(file);
                file.Close();
            }
            else
            {
                pd = new TaskSchedulerData();
            }
        }

        public ActionResult Upload(HttpPostedFileBase file)
        {
            file.SaveAs(GetPath());
            InitScheduler();
            Index();
            return View("Index");
        }
        private string GetPath()
        {
            var name = User.Identity.Name;
            if (User.Identity.IsAuthenticated == false) return null;
            return Server.MapPath("~\\App_Data\\" + name + ".ts");
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