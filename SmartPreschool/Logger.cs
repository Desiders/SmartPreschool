﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SmartPreschool
{
    internal class Logger
    {
        // Customized ILoggerProvider, writes logs to text files
        public class FileLoggerProvider : ILoggerProvider
        {
            private readonly StreamWriter _logFileWriter;

            public FileLoggerProvider(StreamWriter logFileWriter)
            {
                _logFileWriter = logFileWriter ?? throw new ArgumentNullException(nameof(logFileWriter));
            }

            public ILogger CreateLogger(string categoryName)
            {
                return new FileLogger(categoryName, _logFileWriter);
            }

            public void Dispose()
            {
                _logFileWriter.Dispose();
            }
        }

        // Customized ILogger, writes logs to text files
        public class FileLogger : ILogger
        {
            private readonly string _categoryName;
            private readonly StreamWriter _logFileWriter;

            public FileLogger(string categoryName, StreamWriter logFileWriter)
            {
                _categoryName = categoryName;
                _logFileWriter = logFileWriter;
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(
                LogLevel logLevel,
                EventId eventId,
                TState state,
                Exception exception,
                Func<TState, Exception, string> formatter)
            {
                // Ensure that only information level and higher logs are recorded
                if (!IsEnabled(logLevel))
                {
                    return;
                }

                // Get the formatted log message
                var message = formatter(state, exception);

                //Write log messages to text file
                _logFileWriter.WriteLine($"[{logLevel}] [{_categoryName}] {message}");
                _logFileWriter.Flush();
            }
        }
    }
}
