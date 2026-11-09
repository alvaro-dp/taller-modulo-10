using TiendaApi.Options;
using TiendaApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Módulo 9: configuración tipada, validada al arrancar.
builder.Services.AddOptions<TiendaOptions>()
    .Bind(builder.Configuration.GetSection(TiendaOptions.Seccion))
    .ValidateDataAnnotations()
    .ValidateOnStart();

// Módulo 8: tiempos de vida.
builder.Services.AddSingleton<IProductoRepository, ProductoRepositoryMemoria>();
builder.Services.AddScoped<IContextoSolicitud, ContextoSolicitud>();

var app = builder.Build();

app.MapControllers();
app.Run();
