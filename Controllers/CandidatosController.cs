using Microsoft.AspNetCore.Mvc;
using projetoJobs.Contexts;
using projetoJobs.Models;

public class CandidatosController : Controller
{
    private readonly AppDbContext _context;

    public CandidatosController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var candidatos = _context.Candidatos.ToList();
        return View(candidatos);
    }
    public IActionResult Dashboard()
{
    var candidatoId = HttpContext.Session.GetInt32("CandidatoId");

    if (candidatoId == null)
    {
        return RedirectToAction("LoginCandidato", "Auth");
    }

    var candidato = _context.Candidatos.FirstOrDefault(c => c.Id == candidatoId);

    ViewBag.Nome = candidato?.Nome;

    return View();
}

}

