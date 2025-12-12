using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetoJobs.Contexts;
using projetoJobs.Models;

namespace projetoJobs.Controllers
{
    public class CandidatosController : Controller
    {
        private readonly AppDbContext _context;

        public CandidatosController(AppDbContext context)
        {
            _context = context;
        }

        // LISTA TODAS AS VAGAS DISPONÍVEIS
        public IActionResult VagasDisponiveis()
        {
            var vagas = _context.Vagas
                .Include(v => v.Empresas)
                .ToList();

            return View(vagas);
        }

        // ENVIAR CANDIDATURA
        [HttpPost]
        public IActionResult Candidatar(int vagaId)
        {
            var candidatoId = HttpContext.Session.GetInt32("CandidatoId");

            if (candidatoId == null)
                return RedirectToAction("Login", "Auth");

            var candidatura = new Candidatura
            {
                CandidatoId = candidatoId.Value,
                VagaId = vagaId,
                DataCandidatura = DateTime.Now
            };

            _context.Candidaturas.Add(candidatura);
            _context.SaveChanges();

            TempData["msg"] = "Candidatura enviada com sucesso!";
            return RedirectToAction("VagasDisponiveis");
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
