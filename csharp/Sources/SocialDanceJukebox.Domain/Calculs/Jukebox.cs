using System;
using SocialDanceJukebox.Domain.Calculs.Contracts;
using SocialDanceJukebox.Domain.Dto;

namespace SocialDanceJukebox.Domain.Calculs
{
    public class Jukebox
    {
        private readonly ChansonConvertisseur _convertisseur = new ChansonConvertisseur();
        private readonly IVecteurPreparateur _preparateur;
        private readonly ITrieur _trieur;
        private readonly IScoreCalculeur _scoreCalculeur;

        public Jukebox(IVecteurPreparateur preparateur, ITrieur trieur, IScoreCalculeur scoreCalculeur)
        {
            _preparateur = preparateur;
            _trieur = trieur;
            _scoreCalculeur = scoreCalculeur;
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
            _trieur.Tri(data);

            Print(data);

            /* Calcule le score. */
            var score = _scoreCalculeur.Calcule(data);
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

