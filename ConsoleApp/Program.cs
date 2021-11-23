using ConsoleApp;
using Core.Entities;
using Core.Interfaces;
using Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace HelloWorld
{
    class Program
    {
        static MovieService movieService { get; set; }

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.Configure<YasserDatabaseSettings>(context.Configuration.GetSection(nameof(YasserDatabaseSettings)));
                    services.AddSingleton<IYasserDatabaseSettings>(sp => sp.GetRequiredService<IOptions<YasserDatabaseSettings>>().Value);
                    services.AddScoped<MovieService>();
                    services.AddScoped<IMovie, MovieRepository>();
                }).UseSerilog()
                .Build();

            var svc = ActivatorUtilities.CreateInstance<MovieUI>(host.Services);
            svc.Menu();
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIOREMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}