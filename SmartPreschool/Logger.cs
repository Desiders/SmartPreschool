using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SmartPreschool;

internal class Logger
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly string filePath;

        public FileLoggerProvider(string filePath)
        {
            var info = new FileInfo(filePath);
            this.filePath = info.FullName;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(categoryName, filePath);
        }

        public void Dispose() { }
    }

    public class FileLogger : ILogger, IDisposable
    {
        // https://metanit.com/sharp/aspnet6/7.4.php
        private readonly string _categoryName;
        private readonly string _filePath;
        static readonly Lock _lock = new();

        public FileLogger(string categoryName, string filePath)
        {
            _filePath = filePath;
            _categoryName = categoryName;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return this;
        }

        public void Dispose()
        {
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;

            // Вообще там есть возможность добавить форматтер для такого, но это долго
            var message = $"[{logLevel}] [{_categoryName}] {formatter(state, exception)}";

            lock (_lock)
            {
                File.AppendAllText(_filePath, message + Environment.NewLine);
            }
        }
    }
}
