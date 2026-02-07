using E_Commerce.Application.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace E_Commerce.Infrastructure.Logging
{
    public class SerlogLogger : IAppLogger
    {
        private readonly ILogger<SerlogLogger> _logger;

        public SerlogLogger(ILogger<SerlogLogger> logger) 
        {
            _logger = logger;
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }

        public void LogError(string message, Exception exception = null)
        {
            _logger.LogError(exception, message);
        }
    }
}