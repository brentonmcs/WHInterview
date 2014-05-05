using System.Web.Mvc;
using WH.Business.Services;
using WH.Domain;

namespace WH.Interview.Controllers
{
    public class HomeController : Controller
    {
        

        

        public ActionResult Index()
        {
            
        
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