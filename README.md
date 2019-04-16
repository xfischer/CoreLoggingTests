# CoreLoggingTests

**A simple test solution with :**
- A library emiting logs with ILogger from *Microsoft.Extensions.Logging.Abstractions*
- A console app referencing the library and setting up filtered listeners using Dependency Injection

**Conclusion :**
- You can setup logging in a library without forcing a concrete logging implementation.
- It's up to the app referencing your library to choose whether to listen to traces and to choose among well known providers (NLog, Serilog, ...)

**Sources :**
- [Logging in ASP.NET Core](https://docs.microsoft.com/aspnet/core/fundamentals/logging/?view=aspnetcore-2.)
