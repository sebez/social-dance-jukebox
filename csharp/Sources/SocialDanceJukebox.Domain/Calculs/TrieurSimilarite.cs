using SocialDanceJukebox.Domain.Calculs.Contracts;
using SocialDanceJukebox.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialDanceJukebox.Domain.Calculs
{
    public class TrieurSimilarite : ITrieur
    {
        private readonly IDistance _distance;

        public TrieurSimilarite(IDistance distance)
        {
            _distance = distance;
        }

        public void Tri(CalculData data)
        {
            var random = new Random(DateTime.Now.Millisecond);

            /* Calcule la matrice des similarités. */
            var dim = data.Vecteurs.Count;
            var axeX = data.Vecteurs.ToList();
            var axeY = data.Vecteurs.ToList();
            var matriceSimilarite = new MatriceSimilarite();

            for (int x = 1; x <= dim; x++)
            {
                for (int y = 1; y <= dim; y++)
                {
                    var vectX = axeX[x - 1];
                    var vectY = axeY[y - 1];
                    matriceSimilarite[vectX, vectY] = _distance.Calcule(vectX, vectY);
                }
            }

            var vecteursRestant = data.Vecteurs.ToList();

            /* Choisit le premier vecteur. */
            var premierVecteur = data.Vecteurs.First();
            premierVecteur.Ordre = 1;
            vecteursRestant.Remove(premierVecteur);

            var vecteurPrecedent = premierVecteur;

            /* Cherche l'ordre n itérativement. */
            for (int n = 2; n <= dim; n++)
            {
                /* Récupère les distances avec les vecteurs restants. */
                var distanceMap = vecteursRestant.ToDictionary(v => v, v => matriceSimilarite[vecteurPrecedent, v]);

                /* Trie par distance */
                var vecteursRestantTries = distanceMap.OrderBy(t => t.Value).Select(t => t.Key).ToList();

                /* Choisie le prochain vecteur comme étant le médian. */
                var prochainVecteur = GetMedian(vecteursRestantTries);

                /* Ajoute le prochain vecteur. */
                prochainVecteur.Ordre = n;
                vecteursRestant.Remove(prochainVecteur);
            }

        }

        private VecteurChanson GetMedian(IList<VecteurChanson> vecteurs)
        {
            int count = vecteurs.Count;
            switch (count)
            {
                case 0:
                    throw new NotSupportedException("Liste vide.");
                case 1:
                    return vecteurs.Single();
                default:
                    if (count % 2 == 0)
                    {
                        /* Cas d'un nombre pair */
                        return vecteurs[(count / 2) - 1];
                    }
                    else
                    {
                        /* Cas d'un nombre impair */
                        return vecteurs[(count - 1) / 2];
                    }
            }
        }
    }


}
