using Microsoft.AspNetCore.Mvc;
using projetoJobs.Contexts;
using projetoJobs.Models;

namespace projetoJobs.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        // INJEÇÃO DE DEPENDÊNCIA — CORRETO!
        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        // ======= VIEWS =======
        public IActionResult LoginEmpresa() => View();
        public IActionResult LoginCandidato() => View();
        public IActionResult RegisterEmpresa() => View();
        public IActionResult RegisterCandidato() => View();
        public IActionResult Login() => View();
        public IActionResult Register() => View();


        // ==========================
        // LOGIN EMPRESA
        // ==========================
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

            HttpContext.Session.SetInt32("EmpresaId", empresa.Id);
            HttpContext.Session.SetString("EmpresaNome", empresa.Nome);

            return RedirectToAction("Dashboard", "Empresas");
        }


        // ==========================
        // LOGIN CANDIDATO
        // ==========================
        [HttpPost]
        public IActionResult LoginCandidato(string email, string senha)
        {
            var candidato = _context.Candidatos
                .FirstOrDefault(c => c.Email == email && c.Senha == senha);

            if (candidato == null)
            {
                ViewBag.Error = "Email ou senha incorretos.";
                return View();
            }

            HttpContext.Session.SetInt32("CandidatoId", candidato.Id);
            HttpContext.Session.SetString("CandidatoNome", candidato.Nome);

            return RedirectToAction("Dashboard", "Candidatos");
        }


        // ==========================
        // CADASTRO EMPRESA
        // ==========================
        [HttpPost]
        public IActionResult RegisterEmpresa(Empresa empresa)
        {
            if (!ModelState.IsValid)
                return View(empresa);

            _context.Empresas.Add(empresa);
            _context.SaveChanges();

            HttpContext.Session.SetInt32("EmpresaId", empresa.Id);
            HttpContext.Session.SetString("EmpresaNome", empresa.Nome);

            return RedirectToAction("Dashboard", "Empresas");
        }


        // ==========================
        // CADASTRO CANDIDATO
        // ==========================
        [HttpPost]
        public IActionResult RegisterCandidato(Candidato candidato)
        {
            if (!ModelState.IsValid)
                return View(candidato);

            _context.Candidatos.Add(candidato);
            _context.SaveChanges();

            HttpContext.Session.SetInt32("CandidatoId", candidato.Id);
            HttpContext.Session.SetString("CandidatoNome", candidato.Nome);

            return RedirectToAction("Dashboard", "Candidatos");
        }


        // ==========================
        // LOGOUT
        // ==========================
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
