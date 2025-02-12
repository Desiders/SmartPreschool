using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading;
using Microsoft.Extensions.Options;
using static SmartPreschool.Database;
using static SmartPreschool.Logger;

namespace SmartPreschool;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    public static void Main()
    {
        var logFilePath = "log.txt";
        var connectionString = "Data Source=database.db";

        var services = new ServiceCollection();
        services.AddLogging(builder =>
        {
            builder.AddProvider(new FileLoggerProvider(logFilePath));

        });
        services.AddDbContext<AppDbContext>(builder =>
        {
            builder.UseSqlite(connectionString);
        }, ServiceLifetime.Singleton);

        var provider = services.BuildServiceProvider();

        using (var scope = provider.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var logger = provider.GetRequiredService<ILogger<Application>>();

            db.Database.EnsureCreated();

            logger.LogInformation("Database created");
            logger.LogInformation("Start application");

            new Migrations.Groups(db).Migrate();
            db.SaveChanges();

            logger.LogDebug("Migrations finished");
        }

        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm(provider));
    }
}