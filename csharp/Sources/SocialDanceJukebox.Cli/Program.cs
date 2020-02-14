using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SocialDanceJukebox.Infrastructure.Adapters;

namespace SocialDanceJukebox.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            Config();

            var printer = new Printer();
            var loader = new ExcelCorpusLoader(new ExcelCorpusLoaderConfig
            {
            });

            var playlist = loader.LoadPlaylist();

            printer.Print(playlist);
        }

        private static void Config()
        {
            // TODO fix
            IConfiguration config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", true, true)
              .Build();


            Console.WriteLine("Social Dance Jukebox CLI");

            // TODO fix
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("SocialDanceJukebox.Cli.Program", LogLevel.Debug)
                    .AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<Program>();
            logger.LogInformation("Example log message");
        }
    }
}
