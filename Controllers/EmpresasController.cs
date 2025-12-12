using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetoJobs.Contexts;
using projetoJobs.Models;

namespace projetoJobs.Controllers
{
    [Route("[controller]")]
    public class EmpresasController : Controller
    {
        private readonly AppDbContext _context;

        public EmpresasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("/Dashboard")]
        public IActionResult Dashboard()
        {
            // Pegando o ID da empresa logada da sessão (ajuste conforme seu login)
            int? empresaId = HttpContext.Session.GetInt32("EmpresaId");

            if (empresaId == null)
                return RedirectToAction("Login", "Auth"); // se não estiver logada

            // Carregando vagas da empresa com candidaturas e candidatos
            var vagas = _context.Vagas
                .Include(v => v.Curriculos)
                .ThenInclude(c => c.Candidato)
                .Where(v => v.EmpresasId == empresaId)
                .ToList();

            return View(vagas); // passa a lista de vagas para a view
        }
    }
}
