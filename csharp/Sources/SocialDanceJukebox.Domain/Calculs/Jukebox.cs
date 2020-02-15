using System;
using SocialDanceJukebox.Domain.Calculs.Contracts;
using SocialDanceJukebox.Domain.Dto;

namespace SocialDanceJukebox.Domain.Calculs
{
    public class Jukebox
    {
        private readonly ChansonConvertisseur _convertisseur = new ChansonConvertisseur();
        private readonly IVecteurPreparateur _preparateur;

        public Jukebox(IVecteurPreparateur preparateur)
        {
            _preparateur = preparateur;
        }

        public void AutoDj(Playlist playlist)
        {
            if(playlist == null)
            {
                throw new ArgumentNullException(nameof(playlist));
            }

            var data = new CalculData();
            
            /* Convertit les chansons en vecteurs. */
            foreach(var chanson in playlist.Chansons)
            {
                var vecteur = _convertisseur.CalculVecteurChanson(chanson);
                data.Vecteurs.Add(vecteur);
            }

            Print(data);

            /* Normalise les vecteurs. */
            _preparateur.Prepare(data);

            Print(data);

            /* Trie */
            new TrieurSimilarite().Tri(data);

            Print(data);

            /* Calcule le score. */
            IDistance distance = new DistanceEuclidienne();
            var score = new ScoreCalculeur().Calcule(data, distance);
            Console.WriteLine();
            Console.WriteLine($"Score : {100*score:##}%");
        }

        private void Print(CalculData data)
        {
            Console.WriteLine("*** Vecteurs ***");
            foreach (var vecteur in data.Vecteurs)
            {
                Console.WriteLine($"[{string.Join(" ; ", vecteur.Values)}]");
            }
        }
    }
}

