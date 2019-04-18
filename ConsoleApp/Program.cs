using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using System;

namespace ConsoleApp
{
    class Program
    {
        const bool USE_DEPENDENCY_INJECTION = true;
        static void Main(string[] args)
        {
            if (USE_DEPENDENCY_INJECTION)
            {
                // Setting up dependency injection
                var serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);
                var serviceProvider = serviceCollection.BuildServiceProvider();

                // Get an instance of the service
                // ILogger instance will be injected by dependency injection
                // Note : if no DI is setup, MyService will work because ILogger is null-checked (ie _logger?.Info(msg))
                var myService = serviceProvider.GetService<MyNetStandardLib.MyService>();

                // Call the service (logs are made here)
                myService.DoSomething();
            }
            else
            {
                // Create an instance of the service

                MyNetStandardLib.MyService myService = new MyNetStandardLib.MyService();

                // Call the service (logs are made here)
                myService.DoSomething();
            }


            Console.ReadLine();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging(config =>
            {
                config.AddDebug(); // Log to debug (debug window in Visual Studio or any debugger attached)
                config.AddConsole(); // Log to console (colored !)
            })
            .Configure<LoggerFilterOptions>(options =>
            {
                options.AddFilter<DebugLoggerProvider>(null /* category*/ , LogLevel.Information /* min level */);
                options.AddFilter<ConsoleLoggerProvider>(null  /* category*/ , LogLevel.Information /* min level */);
            })
            .AddTransient<MyNetStandardLib.MyService>(); // Register service from the library
            
        }


    }
}
