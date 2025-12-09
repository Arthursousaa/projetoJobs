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
}

