using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetoJobs.Contexts;
using projetoJobs.Models;

namespace projetoJobs.Controllers
{
    public class VagasController : Controller
    {
        public JobsContext _context = new JobsContext();

        public IActionResult Index()
        {
            var vagas = _context.Vagas.Include(v => v.Empresas).ToList();
            return View(vagas);
        }

        [HttpPost]
        public IActionResult Criar(Vaga vaga)
        {
            _context.Vagas.Add(vaga);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
