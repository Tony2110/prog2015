using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using SortingCenter;

namespace WebRegister.Controllers
{
    public class HomeController : Controller
    {
        private CargoData pd;
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated == false) return View("AutificatedNULL");
            InitSorting();
            return View(pd);
        }

        private void InitSorting()
        {
            var pdName = GetSortingName();
            if (pdName != null && System.IO.File.Exists(pdName))
            {
                var file = System.IO.File.OpenRead(pdName);
                var xs = new XmlSerializer(typeof(CargoData));
                pd = (CargoData)xs.Deserialize(file);
                file.Close();
            }
            else
            {
                pd = new CargoData();
            }
        }

        public ActionResult Upload(HttpPostedFileBase file)
        {
            file.SaveAs(GetSortingName());
            InitSorting();
            Index();
            return View("Index");
        }
        private string GetSortingName()
        {
            var name = User.Identity.Name;
            if (User.Identity.IsAuthenticated == false) return null;
            return Server.MapPath("~\\App_Data\\" + name + ".cargo");
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
