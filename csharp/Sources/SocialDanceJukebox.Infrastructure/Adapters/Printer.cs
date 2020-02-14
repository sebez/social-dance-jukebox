using System;
using SocialDanceJukebox.Domain.Dto;

namespace SocialDanceJukebox.Infrastructure.Adapters
{
    public class Printer
    {
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
