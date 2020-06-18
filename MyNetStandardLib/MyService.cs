using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MyNetStandardLib
{
    /// <summary>
    /// Test service
    /// </summary>
    public class MyService
    {
        private readonly ILogger<MyService> _logger;
        /// <summary>
        /// Contructor taking an ILogger provided by DI container
        /// </summary>
        /// <param name="logger"></param>
        public MyService(ILogger<MyService> logger = null)
        {
            if (logger == null)
            {
                Console.WriteLine("Logger is null (Console), using NullLogger");
                Trace.TraceWarning("Logger is null (Trace), using NullLogger");
                Debug.WriteLine("Logger is null (Debug),using NullLogger");
            }

            _logger = logger ?? NullLogger<MyService>.Instance;
            _logger.LogDebug("Logger OK (logger)");

        }


        /// <summary>
        /// Test method logging at every level
        /// </summary>
        public void DoSomething()
        {
            _logger.LogDebug("DoSometing DEBUG message");
            _logger.LogTrace("DoSometing TRACE message");
            _logger.LogInformation("DoSometing INFO message");
            _logger.LogWarning("DoSometing WARN message");
            _logger.LogError("DoSometing ERROR message");
            _logger.LogCritical("DoSometing CRITICAL message");

        }
    }
}
