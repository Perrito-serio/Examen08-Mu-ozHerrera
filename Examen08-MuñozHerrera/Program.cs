// ========= Usings necesarios para el proyecto ===========
using Examen08_MuñozHerrera.Core.Interfaces;
using Examen08_MuñozHerrera.Infrastructure.Data;
using Examen08_MuñozHerrera.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

// ========= Creación del Constructor de la Aplicación ===========
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ========= Configuración de Servicios ===========
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>(); 
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ========= Construcción de la Aplicación ===========
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    // ...habilita el middleware de Swagger para generar la documentación.
    app.UseSwagger();
    // ...habilita el middleware de Swagger UI para mostrar la página web interactiva.
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
