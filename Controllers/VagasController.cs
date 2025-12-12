using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetoJobs.Contexts;
using projetoJobs.Models;

namespace projetoJobs.Controllers
{
    public class VagasController : Controller
    {
        private readonly AppDbContext _context;

        public VagasController(AppDbContext context)
        {
            _context = context;
        }

        
        // public IActionResult Index()
        // {
        //     var vagas = _context.Vagas
        //         .Include(v => v.Empresa)
        //         .ToList();

        //     return View(vagas);
        // }

        // [HttpPost]
        // public IActionResult Criar(Vaga vaga)
        // {
        //     _context.Vagas.Add(vaga);
        //     _context.SaveChanges();
        //     return RedirectToAction("Index");
        // }
    }
}
