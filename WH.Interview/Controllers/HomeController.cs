using System.Web.Mvc;
using WH.Business.Services;
using WH.Domain;

namespace WH.Interview.Controllers
{
    public class HomeController : Controller
    {
        private readonly BetImporter _betImporter;

        public HomeController(BetImporter betImporter)
        {
            _betImporter = betImporter;
        }

        public ActionResult Index()
        {
            
            ViewBag.ResultedBetCount = _betImporter.ResultedBets.Count;
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