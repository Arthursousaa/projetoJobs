using Microsoft.AspNetCore.Mvc;

namespace projetoJobs.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
