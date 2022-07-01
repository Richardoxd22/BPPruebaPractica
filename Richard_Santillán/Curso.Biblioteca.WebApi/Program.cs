using Curso.Biblioteca.Aplicacion.ServicioDef;
using Curso.Biblioteca.Aplicacion.ServicioImpl;
using Curso.Biblioteca.Dominio.RepositoriosDef;
using Curso.Biblioteca.Infraestructura.Context;
using Curso.Biblioteca.Infraestructura.RepositorioImplementacion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BibliotecaDbContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Inyeccion
builder.Services.AddTransient<IAutorRepositorio, AutorRepositorio>();
builder.Services.AddTransient<ILibroRepositorio, LibroRepositorio>();
builder.Services.AddTransient<IEditorialRepositorio, EditorialRepositorio>();

builder.Services.AddTransient<IAutorServicio, AutorServicio>();
builder.Services.AddTransient<ILibroServicio, LibroServicio>();
builder.Services.AddTransient<IEditorialServicio, EditorialServicio>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
