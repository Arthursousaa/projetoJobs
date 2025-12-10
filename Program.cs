using Microsoft.EntityFrameworkCore;
using projetoJobs.Contexts;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// DbContext (SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Sessão
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

var app = builder.Build();

// HTTPS
app.UseHttpsRedirection();

// Arquivos estáticos (css, js, imagens)
app.UseStaticFiles();

// Roteamento
app.UseRouting();

// Autorização (se usar futuramente)
app.UseAuthorization();

// Sessão (DEPOIS do routing)
app.UseSession();

// Rotas MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
