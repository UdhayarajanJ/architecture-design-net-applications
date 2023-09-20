using Serilog;
using Serilog.Events;

namespace repo.application.Extensions
{
    public static class SerilogServicesExtension
    {
        public static void ConfigureSeriLogService(this ILoggingBuilder logger)
        {
            string LogFile = Path.Combine(Environment.CurrentDirectory, "LogInformation", "logs-.txt");

            string outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj} {Exception} {NewLine} {NewLine}";
            var loggerConfig = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .WriteTo.Console(outputTemplate: outputTemplate)
                    .WriteTo.File(LogFile, LogEventLevel.Error, rollingInterval: RollingInterval.Day, outputTemplate: outputTemplate)
                    .CreateLogger();

            logger.ClearProviders();
            logger.AddSerilog(loggerConfig);
        }
    }
}
