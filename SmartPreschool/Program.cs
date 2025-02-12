using System;
using System.Data.SQLite;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using static SmartPreschool.Database;
using static SmartPreschool.Logger;

namespace SmartPreschool
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var  logFilePath = "log.txt";
            var connectionString = "Data Source=database.db";
            var logFileWriter = new StreamWriter(logFilePath, append: true);

            var services = new ServiceCollection();
            services.AddSingleton(implementationFactory: _ => {
                var loggerFactory = LoggerFactory.Create(builder =>
                {
                    builder.AddProvider(new FileLoggerProvider(logFileWriter));
                });
                var logger = loggerFactory.CreateLogger("Program");

                return logger;
            });
            services.AddSingleton(implementationFactory: provider =>
            {
                var logger = provider.GetRequiredService<ILogger>();

                var db = new AppDbContext(connectionString);
                db.Database.EnsureCreated();

                logger.LogDebug("Database created");

                return db;
            });
            //services.AddSingleton(implementationFactory: provider => {
            //    var logger = provider.GetRequiredService<ILogger>();

            //    var conn = new SQLiteConnection(connectionString);

            //    conn.Open();

            //    using (var cmd = new SQLiteCommand("SELECT sqlite_version();", conn))
            //    {
            //        var version = cmd.ExecuteScalar().ToString();

            //        logger.LogDebug($"SQLite version: {version}");
            //    }

            //    return conn;
            //});
            var provider = services.BuildServiceProvider();

            var logger = provider.GetRequiredService<ILogger>();
            var db = provider.GetRequiredService<AppDbContext>();

            logger.LogInformation("Start application");

            new Migrations.Groups(db).Migrate();
            db.SaveChanges();

            logger.LogDebug("Migrations finished");

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(provider));

            //var conn = provider.GetRequiredService<SQLiteConnection>();

            //conn.Close();
            db.Dispose();
        }
    }
}