using Cloud.Faast.Integracion.Dao.Context;
using Cloud.Faast.Integracion.Dao.Repository.Empleado;
using Cloud.Faast.Integracion.Dao.Repository.Persona;
using Cloud.Faast.Integracion.Dao.Repository.Seguridad;
using Cloud.Faast.Integracion.Filters;
using Cloud.Faast.Integracion.Interface.Repository.Empleado;
using Cloud.Faast.Integracion.Interface.Repository.Persona;
using Cloud.Faast.Integracion.Interface.Repository.Seguridad;
using Cloud.Faast.Integracion.Interface.Service.Empleado;
using Cloud.Faast.Integracion.Interface.Service.Persona;
using Cloud.Faast.Integracion.Interface.Service.Seguridad;
using Cloud.Faast.Integracion.Service.Empleado;
using Cloud.Faast.Integracion.Service.Persona;
using Cloud.Faast.Integracion.Service.Seguridad;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Web;
using System;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{

    var builder = WebApplication.CreateBuilder(args);

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


    //GlobalDiagnosticsContext.Set("connectionString", builder.Configuration.GetConnectionString("Progreso"));
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
