using System;
using Microsoft.Extensions.Logging;
using SocialDanceJukebox.Domain.Dto;

namespace SocialDanceJukebox.Infrastructure.Adapters
{
    public class Printer
    {
        private readonly ILogger _logger;

        public Printer(ILogger logger)
        {
            _logger = logger;
        }

        public void Print(Chanson chanson)
        {
            Console.WriteLine($" -  {chanson.Titre} ({chanson.Artiste}) | {chanson.Tempo}MPM | {chanson.Type} | {chanson.Genre} | {chanson.Frequence} ");
        }

        public void Print(Playlist playlist)
        {
            Console.WriteLine($"*** Playlist {playlist.Titre} ****");
            Console.WriteLine($"{playlist.Chansons.Count} chansons dans la playlist");
            foreach (var chanson in playlist.Chansons)
            {
                this.Print(chanson);
            }
        }
    }
}
