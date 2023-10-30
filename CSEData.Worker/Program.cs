using Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.EntityFrameworkCore;
using CSEData.Worker;
using Serilog.Events;
using Serilog;
using CSEData.Persistence;
using CSEData.Application;



var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()
                .Build();


var connectionString = configuration.GetConnectionString("DefaultConnection");
var assemblyName = typeof(Worker).Assembly.FullName;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

try
{
    IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .UseSerilog()
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new WorkerModule(connectionString, assemblyName, configuration));
        builder.RegisterModule(new PersistenceModule(connectionString, assemblyName));
        builder.RegisterModule(new ApplicationModule());
        builder.RegisterModule(new InfrastructureModule());

    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString, m => m.MigrationsAssembly(assemblyName)));
    })
    .Build();

    Log.Information("Application starting up!");
    await host.RunAsync();
}
catch (Exception ex)
{
    Log.Error(ex.Message);
}
finally
{
    Log.CloseAndFlush();
}
