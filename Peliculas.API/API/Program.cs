using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios.Generos;
using Abstracciones.Interfaces.Servicios.Media;
using DA;
using DA.Repositorios;
using Flujo;
using Reglas;
using Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddScoped<IRepositorioDapper, RepositorioDapper>();
builder.Services.AddScoped<IConfiguracion, Configuracion>();
builder.Services.AddScoped<IGeneroFlujo, GeneroFlujo>();
builder.Services.AddScoped<IGeneroServicio, GeneroServicio>();
builder.Services.AddScoped<IListaVisualizacionDA, ListaVisualizacionDA>();
builder.Services.AddScoped<IListaVisualizacionFlujo, ListaVisualizacionFlujo>();
builder.Services.AddScoped<IMediaServicio, MediaServicio>();
builder.Services.AddScoped<IMediaFlujo, MediaFlujo>();
builder.Services.AddScoped<IFavoritoFlujo, FavoritoFlujo>();
builder.Services.AddScoped<IFavoritoDA, FavoritoDA>();

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
