using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetoJobs.Contexts;
using projetoJobs.Models.ViewModels;
using System.Linq;

namespace projetoJobs.Controllers
{
    public class CurriculosController : Controller
    {
        private readonly AppDbContext _context;

        public CurriculosController(AppDbContext context)
        {
            _context = context;
        }

        // Mostra apenas os currículos do candidato logado
        public IActionResult MeusCurriculos()
        {
            var candidatoId = HttpContext.Session.GetInt32("CandidatoId");

            if (candidatoId == null)
                return RedirectToAction("LoginCandidato", "Auth");

            var lista = _context.Curriculos
                .Where(c => c.CandidatosId == candidatoId)
                .Select(c => new CurriculoViewModel
                {
                    CurriculoId = c.Id,
                    NomeArquivo = c.NomeArquivo,
                    CaminhoArquivo = c.CaminhoArquivo,
                    DataEnvio = c.DataEnvio,
                    CandidatoNome = c.Candidato!.Nome,
                    CandidatoEmail = c.Candidato.Email,
                    Cidade = c.Candidato.Cidade,
                    Estado = c.Candidato.Estado,
                    ResumoPerfil = c.Candidato.ResumoPerfil
                })
                .ToList();

            return View(lista);
        }

        public IActionResult Download(int id)
        {
            var cv = _context.Curriculos.FirstOrDefault(x => x.Id == id);

            if (cv == null)
                return NotFound();

            var caminhoFisico = Path.Combine("wwwroot", cv.CaminhoArquivo!);

            if (!System.IO.File.Exists(caminhoFisico))
                return NotFound("Arquivo não encontrado.");

            var bytes = System.IO.File.ReadAllBytes(caminhoFisico);

            return File(bytes, "application/pdf", cv.NomeArquivo);
        }
    }
}
