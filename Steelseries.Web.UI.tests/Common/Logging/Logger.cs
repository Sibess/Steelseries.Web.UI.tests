using System;
using NLog;
using NLog.Config;
using NLog.Targets;
using System.Threading;

namespace Steelseries.Web.UI.tests.Common.Logging
{
    public sealed class Logger
    {
        private static readonly Lazy<Logger> LazyInstance = new Lazy<Logger>(() => new Logger());
        private static readonly ThreadLocal<ILogger> Log = new ThreadLocal<ILogger>(() => LogManager.GetLogger(Thread.CurrentThread.ManagedThreadId.ToString()));

        private Logger()
        {
            LogManager.Configuration = GetConfiguration();
        }

        private LoggingConfiguration GetConfiguration()
        {
            var layout = "${date:format=yyyy-MM-dd HH\\:mm\\:ss} ${level:uppercase=true} - ${message} ${exception:format=Message}";
            var config = new LoggingConfiguration();
            config.AddRule(LogLevel.Info, LogLevel.Fatal, new ConsoleTarget("logconsole")
            {
                Layout = layout
            });
            return config;
        }

        public static Logger Instance => LazyInstance.Value;

        public void Debug(string message, Exception exception = null)
        {
            Log.Value.Debug(exception, message);
        }

        public void Info(string message)
        {
            Log.Value.Info(message);
        }

        public void Warn(string message)
        {
            Log.Value.Warn(message);
        }

        public void Error(string message)
        {
            Log.Value.Error(message);
        }

        public void Error(Exception exception, string message)
        {
            Log.Value.Error(exception, message);
        }

        public void Fatal(Exception exception, string message)
        {
            Log.Value.Fatal(exception, message);
        }
    }
}
