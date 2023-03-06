using Hangfire;
using Hangfire.Console;
using Hangfire.SqlServer;
using Hangfire.RecurringJobAdmin;
using HangfireBasicAuthenticationFilter;
using Cloud.Faast.HangFire.Interface.Service.Orsan;
using Cloud.Faast.HangFire.Common;
using Cloud.Faast.HangFire.Extensions;
using System.Reflection;
using Cloud.Faast.HangFire.Dao.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


IConfiguration configEnvironment;

var pre_builder = new ConfigurationBuilder()
      .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var pre_config = pre_builder.Build();
var is_prod = Convert.ToBoolean(pre_config["is_prod"]);

var dashboardTitle = "";

if (is_prod)
{
    var builderEnvironment = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("appsettings.prod.json", optional: false, reloadOnChange: true);

    configEnvironment = builderEnvironment.Build();

    dashboardTitle = "HangFire PROD";
}
else
{
    var builderEnvironment = new ConfigurationBuilder()
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
       .AddJsonFile("appsettings.qa.json", optional: false, reloadOnChange: true);

    configEnvironment = builderEnvironment.Build();

    dashboardTitle = "HangFire QA";
}


var hfCn = configEnvironment.GetConnectionString("HangFire");
var user = configEnvironment.GetSection("Access")["user"]?.ToString();
var pass = configEnvironment.GetSection("Access")["pass"]?.ToString();



// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddHangfire(config => config
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseColouredConsoleLogProvider()
    .UseResultsInContinuations()
    .UseConsole()
    .UseSqlServerStorage(hfCn, new SqlServerStorageOptions
    {
        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        QueuePollInterval = TimeSpan.Zero,
        UseRecommendedIsolationLevel = true,
        UsePageLocksOnDequeue = true,
        DisableGlobalLocks = true,
        DashboardJobListLimit = 50000,
        EnableHeavyMigrations = true
    })
    .UseRecurringJobAdmin()
);

builder.Services.AddHangfireServer(config => config
    .Queues = new[] { "transfer_file_to_orsan" }
);

//builder.Services.AddScoped<IOperacionDocumentoRepository, OperacionDocumentoRepository>();
//builder.Services.AddScoped<IOperationDocumentoRepository, OperationDocumentoRepository>();
//builder.Services.AddScoped<IOperacionDocumentoService, OperacionDocumentoService>();
//builder.Services.AddSingleton(configEnvironment);

#region "Configure Assembly Services"
builder.Services.AddServicesAsInterfaces(Assembly.Load("Cloud.Faast.HangFire"), "Repository");
builder.Services.AddServicesAsInterfaces(Assembly.Load("Cloud.Faast.HangFire"), "Service");
#endregion

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Configuracion Entityframework
var orsanConnectionString = builder.Configuration.GetConnectionString("FastOrsan");
builder.Services.AddDbContextPool<OrsanDbContext>(options => options.UseSqlServer(orsanConnectionString,
                                                                                    opt => opt.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)));


builder.Services.Configure<AppSettings>(configEnvironment.GetSection("AppSettings"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();


app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", context =>
    {
        context.Response.Redirect("hangfire");
        return Task.FromResult(0);
    });
});

// authentication to Dashboard
var _dashOption = new DashboardOptions()
{
    DashboardTitle = dashboardTitle,
    Authorization = new[] {
        new HangfireCustomBasicAuthenticationFilter()
        {
            User = user,
            Pass = pass
        }
    }
};

app.UseHangfireDashboard("/hangfire", _dashOption);
app.MapHangfireDashboard();

app.MapRazorPages();

RecurringJob.AddOrUpdate<IOperacionDocumentoService>
(
    "TransferExcelToFTP",
    x => x.TransferExcelToFTP(null, CancellationToken.None),
    "0 */5 * ? * *",
    TimeZoneInfo.Local,
    queue: "transfer_file_to_orsan"
);

app.Run();
