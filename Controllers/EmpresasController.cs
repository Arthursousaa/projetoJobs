using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetoJobs.Contexts;
using projetoJobs.Models;

public class EmpresasController : Controller
{
    private readonly AppDbContext _context;

    public EmpresasController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Dashboard()
    {
        int empresaId = HttpContext.Session.GetInt32("EmpresaId") ?? 0;

        if (empresaId == 0)
            return RedirectToAction("Login", "Auth");

        var vagas = _context.Vagas
            .Where(v => v.EmpresasId == empresaId)
            .ToList();

        return View(vagas);
    }

    // Criar vaga
    public IActionResult Criar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Criar(Vaga vaga)
    {
        vaga.EmpresasId = HttpContext.Session.GetInt32("EmpresaId") ?? 0;
        _context.Vagas.Add(vaga);
        _context.SaveChanges();

        return RedirectToAction("Dashboard");
    }

    // Editar vaga
    public IActionResult Editar(int id)
    {
        var vaga = _context.Vagas.Find(id);
        if (vaga == null) return NotFound();
        return View(vaga);
    }

    [HttpPost]
    public IActionResult Editar(Vaga vaga)
    {
        _context.Vagas.Update(vaga);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    // Excluir vaga
    [HttpPost]
public IActionResult Excluir(int id)
{
    var vaga = _context.Vagas
        .Include(v => v.Curriculos)
        .FirstOrDefault(v => v.Id == id);

    if (vaga == null)
        return NotFound();

    // excluir currículos vinculados
    if (vaga.Curriculos.Any())
    {
        _context.Curriculos.RemoveRange(vaga.Curriculos);
    }

    // agora pode excluir a vaga
    _context.Vagas.Remove(vaga);
    _context.SaveChanges();

    return RedirectToAction("Dashboard");
}

    [HttpPost]
    public IActionResult ExcluirConfirmado(int id)
    {
        var vaga = _context.Vagas.Find(id);

        if (vaga != null)
        {
            _context.Vagas.Remove(vaga);
            _context.SaveChanges();
        }

        return RedirectToAction("Dashboard");
    }

    // Detalhes
    public IActionResult Detalhes(int id)
    {
        var vaga = _context.Vagas.Find(id);
        if (vaga == null) return NotFound();

        return View(vaga);
    }
}
