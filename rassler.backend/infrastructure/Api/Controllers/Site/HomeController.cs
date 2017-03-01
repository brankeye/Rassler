using System.Web.Mvc;

namespace rassler.backend.infrastructure.Api.Controllers.Site
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
