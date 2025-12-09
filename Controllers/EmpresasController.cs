using Microsoft.AspNetCore.Mvc;
using projetoJobs.Contexts;
using projetoJobs.Models;

namespace projetoJobs.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly AppDbContext _context;

        public EmpresasController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Empresas.ToList());
        }

        [HttpPost]
        public IActionResult Criar(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
