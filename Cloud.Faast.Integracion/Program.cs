using Cloud.Faast.Integracion.Dao.Repository.Common.Seguridad;
using Cloud.Faast.Integracion.Dao.Repository.Metriks.Empleado;
using Cloud.Faast.Integracion.Dao.Repository.Metriks.Persona;
using Cloud.Faast.Integracion.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Web;
using System;
using Cloud.Faast.Integracion.Dao.Context.Metriks;
using Cloud.Faast.Integracion.Interface.Repository.Metriks.Empleado;
using Cloud.Faast.Integracion.Interface.Repository.Metriks.Persona;
using Cloud.Faast.Integracion.Interface.Repository.Common.Seguridad;
using Cloud.Faast.Integracion.Interface.Service.Metriks.Empleado;
using Cloud.Faast.Integracion.Interface.Service.Metriks.Persona;
using Cloud.Faast.Integracion.Interface.Service.Common.Seguridad;
using Cloud.Faast.Integracion.Service.Metriks.Empleado;
using Cloud.Faast.Integracion.Service.Metriks.Persona;
using Cloud.Faast.Integracion.Service.Common.Seguridad;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{

    var builder = WebApplication.CreateBuilder(args);

    //Configuracion ambientes
    IConfiguration configEnvironment;

    var builderEnvironment = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
          .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
          .AddEnvironmentVariables();

    configEnvironment = builderEnvironment.Build();


    // Add services to the container.

    builder.Services.AddControllers(options =>
    {
        options.Filters.Add(typeof(HttpGlobalExceptionFilter));
    });
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddScoped<IPersonaService, PersonaService>();
    builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
    builder.Services.AddScoped<ISeguridadService, SeguridadService>();

    builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
    builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
    builder.Services.AddScoped<ISeguridadRepository, SeguridadRepository>();

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


    //Filters
    builder.Services.AddScoped<AuthorizationFilter>();

    //Configuracion Entityframework
    var progresoConnectionString = builder.Configuration.GetConnectionString("Progreso");
    builder.Services.AddDbContext<ProgresoDbContext>(x => x.UseMySql(progresoConnectionString, ServerVersion.AutoDetect(progresoConnectionString)));

    //Sentry
    builder.WebHost.UseSentry();


    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();


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

    //Sentry
    app.UseSentryTracing();


    GlobalDiagnosticsContext.Set("conexionLog", progresoConnectionString);
}
catch (Exception ex) 
{
    // NLog: catch setup errors
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}
