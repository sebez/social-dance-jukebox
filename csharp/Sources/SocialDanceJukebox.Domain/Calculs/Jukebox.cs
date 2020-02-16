using System;
using System.Linq;
using System.Text;
using SocialDanceJukebox.Domain.Calculs.Contracts;
using SocialDanceJukebox.Domain.Dto;

namespace SocialDanceJukebox.Domain.Calculs
{
    public class Jukebox
    {
        private readonly ChansonConvertisseur _convertisseur = new ChansonConvertisseur();
        private readonly IVecteurPreparateur _preparateur;
        private readonly MatriceSimilariteCalculateur _matriceSimilariteCalculateur;
        private readonly ITrieur _trieur;
        private readonly IScoreCalculeur _scoreCalculeur;

        public Jukebox(IVecteurPreparateur preparateur, MatriceSimilariteCalculateur matriceSimilariteCalculateur, ITrieur trieur, IScoreCalculeur scoreCalculeur)
        {
            _preparateur = preparateur;
            _matriceSimilariteCalculateur = matriceSimilariteCalculateur;
            _trieur = trieur;
            _scoreCalculeur = scoreCalculeur;
        }

        public void AutoDj(Playlist playlist)
        {
            if (playlist == null)
            {
                throw new ArgumentNullException(nameof(playlist));
            }

            var data = new CalculData();

            /* Convertit les chansons en vecteurs. */
            foreach (var chanson in playlist.Chansons)
            {
                var vecteur = _convertisseur.CalculVecteurChanson(chanson);
                data.Vecteurs.Add(vecteur);
            }

            Print(data);

            /* Prépare les vecteurs. */
            _preparateur.Prepare(data);

            Print(data);

            /* Calcule la matrice de similarité. */
            _matriceSimilariteCalculateur.CalculeMatriceSimilarite(data);

            PrintScoreVecteur(data);

            /* Trie */
            _trieur.Tri(data);

            Print(data);

            /* Calcule le score. */
            var score = _scoreCalculeur.Calcule(data);
            Console.WriteLine();
            Console.WriteLine($"Score : {100 * score:##}%");
        }

        private static void PrintScoreVecteur(CalculData data)
        {
            /* Calcule pour chaque vecteur la somme des distances avec tous les autres. */
            /* La distance avec lui-même est zéro. */
            var list = data.Vecteurs.Select(vecteur => data.Vecteurs.Sum(v => data.MatriceSimilarite[vecteur, v])).ToList();
            var sumMax = list.Max();
            var listNormalise = list.Select(x => x / sumMax);
            Console.WriteLine();
            Console.WriteLine("*** Score d'éloignement des vecteurs ***");
            foreach(var sum in listNormalise)
            {
                Console.WriteLine($"Score : {100 * sum:##}%");
            }
            Console.WriteLine();
        }

        private static void Print(CalculData data)
        {
            Console.WriteLine();
            Console.WriteLine("*** Vecteurs ***");
            Console.WriteLine();
            foreach (var vecteur in data.Vecteurs)
            {
                Console.WriteLine($"[{string.Join(" ; ", vecteur.Values)}]");
            }
            Console.WriteLine();

            if (data.MatriceSimilarite != null)
            {
                Console.WriteLine();
                Console.WriteLine("*** Matrice de similarité ***");
                Console.WriteLine();
                var axeX = data.Vecteurs.ToList();
                var axeY = data.Vecteurs.ToList();

                var sb = new StringBuilder();
                foreach (var vectX in axeX)
                {
                    foreach (var vectY in axeY)
                    {
                        var distanceXY = data.MatriceSimilarite[vectX, vectY];
                        sb.Append($" { distanceXY} ");
                    }
                    sb.AppendLine();
                }
                Console.WriteLine(sb);
                Console.WriteLine();
            }

        }
    }
}

