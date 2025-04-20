using Microsoft.EntityFrameworkCore;
using Viajajunto.Data;

var builder = WebApplication.CreateBuilder(args);

// Obtenha o nome do banco de dados a ser usado (MySQL ou InMemory)
var useInMemoryDatabase = builder.Configuration.GetValue<bool>("UseInMemoryDatabase");

// Condicionalmente escolhe o banco de dados com base na configuração
if (useInMemoryDatabase)
{
    // Usa o banco de dados em memória
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseInMemoryDatabase("ViajajuntoInMemoryDb"));
}
else
{
    // Usa o MySQL
    var connectionString = builder.Configuration.GetConnectionString("MySQLConnection");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseMySQL(connectionString));
}

// Outros serviços e configurações
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuração de middlewares
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
