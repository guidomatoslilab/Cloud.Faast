using Cloud.Faast.Integracion.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Web;
using System;
using Cloud.Faast.Integracion.Dao.Context.Metriks;
using Cloud.Faast.Integracion.Extensions;
using System.Reflection;
using Cloud.Faast.Integracion.Middlewares;
using Cloud.Faast.Integracion.Common.VariablesEntorno;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{

    var builder = WebApplication.CreateBuilder(args);

    //Configuracion ambientes

    #region Configuracion de variables entorno

    IConfiguration configEnvironment;

    var builderEnvironment = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
          .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
          .AddEnvironmentVariables();

    configEnvironment = builderEnvironment.Build();

    #endregion

    // Add services to the container.
    builder.Services.AddControllers(options =>
    {
        options.Filters.Add(typeof(HttpGlobalExceptionFilter));
    });


    builder.Services.AddEndpointsApiExplorer();

    #region Swagger

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddSwaggerGen();
    
    #endregion

    #region "Configure Assembly Services"

    builder.Services.AddServicesAsInterfaces(Assembly.Load("Cloud.Faast.Integracion"), "Repository");
    builder.Services.AddServicesAsInterfaces(Assembly.Load("Cloud.Faast.Integracion"), "Service");
    builder.Services.AddServicesAsInterfaces(Assembly.Load("Cloud.Faast.Integracion"), "Query");
    
    #endregion

    #region AutoMapper
    
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    
    #endregion

    #region Filters
    
    builder.Services.AddScoped<AuthorizationFilter>();

    #endregion

    #region Configuracion Entityframework

    var progresoConnectionString = builder.Configuration.GetConnectionString("Progreso");

    builder.Services.AddDbContext<ProgresoDbContext>(x => x.UseMySql(progresoConnectionString, ServerVersion.AutoDetect(progresoConnectionString)));

    #endregion

    #region Sentry
    
    builder.WebHost.UseSentry();

    #endregion

    #region NLog: Setup NLog for Dependency injection 

    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

    #endregion

    #region Configurar Variables de Entorno
    
    builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

    #endregion
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        #region Swagger
        
        app.UseSwagger();
        app.UseSwaggerUI();
        
        #endregion
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    #region MIDDLEWARES

    // custom jwt auth middleware
    app.UseMiddleware<JwtMiddleware>();


    #endregion
    app.Run();

    #region Sentry

    app.UseSentryTracing();

    #endregion
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
    LogManager.Shutdown();
}
