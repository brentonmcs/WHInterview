using System.Linq;
using System.Web.Mvc;
using WH.Business.Services;
using WH.Domain;
using WH.Interview.Models;

namespace WH.Interview.Controllers
{
    public class HomeController : Controller
    {
        private readonly RiskService _riskService;

        public HomeController(RiskService riskService)
        {
            _riskService = riskService;
        }


        public ActionResult Index()
        {

            var model =new RiskViewModel
            {
                HighRiskCustomers = _riskService.HighRiskCustomers.ToList(),
                HighRiskUpCommingBets = _riskService.HighRiskBets.ToList()
            };
        
            return View(model);
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