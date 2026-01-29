using Microsoft.EntityFrameworkCore;
using PruebaAPI4.Data;
using PruebaAPI4.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowLocalHost", politica =>
    {
        politica.WithOrigins("http://127.0.0.1:5500")
                .AllowAnyHeader()
                .AllowAnyMethod();     
    });
});
// 1. Obtener la cadena de conexión del archivo appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// 2. Registrar el DbContext para usar SQL Server
builder.Services.AddDbContext<AgendaContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IContactService, ContactSevice>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors("AllowLocalHost");

app.UseAuthorization();

app.MapControllers();

app.Run();
