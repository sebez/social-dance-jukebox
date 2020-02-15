using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocialDanceJukebox.Domain.Calculs.Contracts;
using SocialDanceJukebox.Domain.Dto;

namespace SocialDanceJukebox.Domain.Calculs
{
    public class SelecteurMedianDistance : IProchainVecteurSelecteur
    {
        public VecteurChanson Selectionne(VecteurChanson vecteurPrecedent, List<VecteurChanson> vecteursRestant, CalculData data)
        {
            /* Récupère les distances avec les vecteurs restants. */
            var distanceMap = vecteursRestant.ToDictionary(v => v, v => data.MatriceSimilarite[vecteurPrecedent, v]);

            /* Trie par distance */
            var vecteursRestantTries = distanceMap.OrderBy(t => t.Value).Select(t => t.Key).ToList();

            /* Choisie le prochain vecteur comme étant le médian. */
            var prochainVecteur = GetMedian(vecteursRestantTries);
            return prochainVecteur;
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
