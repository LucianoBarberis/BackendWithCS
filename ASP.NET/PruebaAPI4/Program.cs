using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PruebaAPI4.Data;
using PruebaAPI4.DTOs;
using PruebaAPI4.Models;
using PruebaAPI4.Repository;
using PruebaAPI4.Services;
using PruebaAPI4.Validations;

var builder = WebApplication.CreateBuilder(args);

// Inyeccion de la politica de CORS para el puerto de Live Server
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowLocalHost", politica =>
    {
        politica.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();     
    });
});

// Servicios
builder.Services.AddScoped<IContactService, ContactSevice>();

// Entity Framework
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AgendaContext>(options => 
{
    options.UseSqlServer(connectionString);
});

// Repository
builder.Services.AddScoped<IRepository<Contacto>,  ContactRepository>();

// Validadores
builder.Services.AddScoped<IValidator<ContactoCreateDto>, AddContactValidation>();
builder.Services.AddScoped<IValidator<ContactoUpdateDto>, UpdateContactValidation>();

builder.Services.AddControllers();
var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseCors("AllowLocalHost");
app.UseAuthorization();
app.MapControllers();
app.Run();
