using WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Extensions;
using WebAPI.Repositories;
using WebAPI.Services;
using WebAPI.DataTransfer;
using NLog;
using NLog.Web;

// Early init of NLog to allow startup and exception logging, before host is built
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("Inicio principal");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddDbContext<DataContext>(option => option.UseSqlite(builder.Configuration.GetConnectionString("sqlite")));

    builder.Services.AddScoped<IFacturaRepository<Factura>, FacturaRepository>();
    builder.Services.AddScoped<Ventas>();
    builder.Services.AddScoped<IFacturaRestService, FacturaRestService>();
    builder.Services.AddScoped<IPersonaRepository<Persona>, PersonaRepository>();
    builder.Services.AddScoped<Directorio>();
    builder.Services.AddScoped<IDirectorioRestService, DirectorioRestService>();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();

    app.MapControllers();

    app.MigrateDatabase().Run();

}
catch (Exception e)
{
    logger.Error(e, "Programa pausado porque hubo una excepcion");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}

