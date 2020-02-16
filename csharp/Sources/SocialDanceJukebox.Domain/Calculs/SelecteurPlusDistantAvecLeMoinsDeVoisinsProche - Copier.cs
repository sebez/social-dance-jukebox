using System;
using System.Collections.Generic;
using System.Linq;
using SocialDanceJukebox.Domain.Calculs.Contracts;
using SocialDanceJukebox.Domain.Dto;

namespace SocialDanceJukebox.Domain.Calculs
{
    /// <summary>
    /// Sélectionne le meilleur candidat en optimisant la distance avec les vecteurs restants.
    /// </summary>
    public class SelecteurMoinsDeVoisinsProchePlusDistant : IProchainVecteurSelecteur
    {
        public VecteurChanson Selectionne(VecteurChanson vecteurPrecedent, List<VecteurChanson> vecteursRestant, CalculData data)
        {
            /* Pour chaque vecteur restant, calcule celui qui a le plus de voisins proches */
            var localDistanceSumMap = vecteursRestant.ToDictionary(v => v, v => vecteursRestant.Sum(w => data.MatriceSimilarite[v, w]));

            /* Groupe par somme croissante */
            var groupByDistance = localDistanceSumMap.GroupBy(t => t.Value, t => t.Key).OrderBy(t => t.Key).ToList();

            /* Prend le groupe avec les voisins les plus proches. */
            var group = groupByDistance.First();

            /* Prend l'élément le plus éloigné du vecteur précédent. */
            var prochainVecteur = group.OrderBy(v => data.MatriceSimilarite[vecteurPrecedent, v]).Last();

            return prochainVecteur;
        }
    }
}
