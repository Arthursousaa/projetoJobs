using Microsoft.AspNetCore.Mvc;
using projetoJobs.Contexts;

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
