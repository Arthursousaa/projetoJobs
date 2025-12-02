using Microsoft.AspNetCore.Mvc;
using projetoJobs.Contexts;
using projetoJobs.Models;

namespace projetoJobs.Controllers
{
    public class CandidatosController : Controller
    {
        public JobsContext _context = new JobsContext();
        
        public IActionResult Index()
        {
            return View(_context.Candidatos.ToList());
        }

        [HttpPost]
        public IActionResult Criar(Candidato candidato)
        {
            _context.Candidatos.Add(candidato);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
