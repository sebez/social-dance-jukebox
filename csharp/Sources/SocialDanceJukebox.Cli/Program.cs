using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SocialDanceJukebox.Domain.Calculs;
using SocialDanceJukebox.Infrastructure.Adapters;

namespace SocialDanceJukebox.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var loggerfactory = Config();
            var logger = loggerfactory.CreateLogger<Program>();


            logger.LogInformation("*** Social Dance Jukebox ***");

            var printer = new Printer(logger);
            var loader = new ExcelCorpusLoader(new ExcelCorpusLoaderConfig
            {
                CheminFichier = @".\Tests\SocialDanceJukebox.Infrastructure.Test\Resources\DataChansons.xlsx"
            });

            var playlist = loader.LoadPlaylist();
            
            printer.Print(playlist);

            var jukebox = new Jukebox();
            jukebox.AutoDj(playlist);
        }

        private static ILoggerFactory Config()
        {
            IConfiguration config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", true, true)
              .Build();
            Console.WriteLine("Social Dance Jukebox CLI");

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("SocialDanceJukebox.Cli.Program", LogLevel.Debug)
                    .AddConsole();
            });

            return loggerFactory;
        }
    }
}
