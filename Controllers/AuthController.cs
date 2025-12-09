using Microsoft.AspNetCore.Mvc;
using projetoJobs.Contexts;



namespace projetoJobs.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult LoginEmpresa()
        {
            return View();
        }

        public IActionResult LoginCandidato()
        {
            return View();
        }

        public IActionResult RegisterEmpresa()
        {
            return View();
        }

        public IActionResult RegisterCandidato()
        {
            return View();
        }

        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult LoginEmpresa(string email, string senha)
        {
            var empresa = _context.Empresas
                .FirstOrDefault(e => e.Email == email && e.Senha == senha);

            if (empresa == null)
            {
                ViewBag.Error = "Email ou senha incorretos.";
                return View();
            }

            return RedirectToAction("Dashboard", "Empresa");
        }

    }
    
}

