﻿using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SocialDanceJukebox.Domain.Calculs;
using SocialDanceJukebox.Infrastructure.Adapters;

namespace SocialDanceJukebox.Cli
{
    class Program
    {
        private const string Chemin = @".\Tests\SocialDanceJukebox.Infrastructure.Test\Resources\DataChansons.xlsx";

        static void Main(string[] args)
        {
            var loggerfactory = Config();
            var logger = loggerfactory.CreateLogger<Program>();


            logger.LogInformation("*** Social Dance Jukebox ***");

            var printer = new Printer(logger);
            var loader = new ExcelCorpusLoader(new ExcelCorpusLoaderConfig
            {
                CheminFichier = Chemin
            });

            var playlist = loader.LoadPlaylist();
            
            printer.Print(playlist);

            var distance = new DistanceBinaire();
            var jukebox = new Jukebox(
                new PreparateurSansEffet(),
                new MatriceSimilariteCalculateur(distance),
                new TrieurSimilarite(distance, new SelecteurMoinsDeVoisinsProchePlusDistant()),
                new ScoreCalculeur(distance));
            jukebox.AutoDj(playlist);

            loader.SavePlayList(playlist);

            ////Process.Start(new FileInfo(Chemin).FullName);
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
