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
    public static async Task Main()
    {
        using var cts = new CancellationTokenSource();

        Application.ApplicationExit += (sender, e) => cts.Cancel();

        /* 
            var localCts = new CancellationTokenSource(); // Form level CTS
            var newToken = CancellationTokenSource.CreateLinkedTokenSource(cts.Token, localCts.Token); // Method level CTS
            newToken.Cancel(); // Call when need to cancel operation
            newToken.Token.ThrowIfCancellationRequested(); // Call to throw when operation is cancelled
        */

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

            await db.Database.EnsureCreatedAsync(cts.Token);

            logger.LogInformation("Database created");
            logger.LogInformation("Start application");

            await new Migrations.Groups(db).MigrateAsync(cts.Token);
            await db.SaveChangesAsync(cts.Token);

            logger.LogDebug("Migrations finished");
        }

        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm(provider));
    }
}