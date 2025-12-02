using Microsoft.AspNetCore.Mvc;
using projetoJobs.Contexts;
using projetoJobs.Models;

namespace projetoJobs.Controllers
{
    public class EmpresasController : Controller
    {
        public JobsContext _context = new JobsContext();

        public IActionResult Index()
        {
            return View();
        }

        // [HttpPost]
        // public IActionResult Criar(Empresa empresa)
        // {
        //     _context.Empresas.Add(empresa);
        //     _context.SaveChanges();
        //     return RedirectToAction("Index");
        // }
    }
}
