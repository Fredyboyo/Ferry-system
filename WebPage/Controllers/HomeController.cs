using System.Web.Mvc;
using Database;
using DTO;

namespace WebPage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index",DBController.GetFerries());
        }


        public ActionResult DisplayFerry(Ferry ferry)
        {
            return View("Ferry", ferry);
        }
    }
}