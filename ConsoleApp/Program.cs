using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using MyNetStandardLib;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);                
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var myService = serviceProvider.GetService<MyService>();
            myService.DoSomething();


            Console.ReadLine();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging(config =>
            {
                config.AddDebug();
                config.AddConsole();
            })
            .Configure<LoggerFilterOptions>(options =>
            {
                options.AddFilter<DebugLoggerProvider>(null, LogLevel.Information);
                options.AddFilter<ConsoleLoggerProvider>(null, LogLevel.Information);
            })
            .AddTransient<MyService>();
            
        }


    }
}
