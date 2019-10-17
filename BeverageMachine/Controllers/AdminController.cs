using System.Web.Mvc;

namespace BeverageMachine.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        // Admin panel - main page
        public ActionResult Index()
        {
            return View();
        }
    }
}