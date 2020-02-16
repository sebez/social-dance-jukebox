using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocialDanceJukebox.Domain.Calculs.Contracts;
using SocialDanceJukebox.Domain.Dto;

namespace SocialDanceJukebox.Domain.Calculs
{
    public class SelecteurPlusEloigne : IProchainVecteurSelecteur
    {
        public VecteurChanson Selectionne(VecteurChanson vecteurPrecedent, List<VecteurChanson> vecteursRestant, CalculData data)
        {
            /* Récupère les distances avec les vecteurs restants. */
            var distanceMap = vecteursRestant.ToDictionary(v => v, v => data.MatriceSimilarite[vecteurPrecedent, v]);

            /* Trie par distance */
            var vecteursRestantTries = distanceMap.OrderBy(t => t.Value).Select(t => t.Key).ToList();

            /* Choisie le prochain vecteur comme étant le médian. */
            return vecteursRestantTries.Last();
        }
    }
}
