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
    public class SelecteurMeilleurCandidat : IProchainVecteurSelecteur
    {
        public VecteurChanson Selectionne(VecteurChanson vecteurPrecedent, List<VecteurChanson> vecteursRestant, CalculData data)
        {
            /* Récupère les distances avec les vecteurs restants. */
            var distanceMap = vecteursRestant.ToDictionary(v => v, v => data.MatriceSimilarite[vecteurPrecedent, v]);

            /* Groupe par distance décroissante */
            var groupByDistance = distanceMap.GroupBy(t => t.Value, t => t.Key).OrderByDescending(t => t.Key).ToList();

            /* Prend le groupe des plus éloignés. */
            var group = groupByDistance.First();

            Console.WriteLine($"Distance du groupe le plus éloigné : {group.Key}");

            /* Pour chaque vecteur du groupe, calcule celui qui a le plus de voisins proches */
            var localDistanceSumMap = group.ToDictionary(v => v, v => vecteursRestant.Sum(w => data.MatriceSimilarite[v, w]));
            foreach(var t in localDistanceSumMap)
            {
                Console.WriteLine($"Somme distance : {t.Value}");
            }

            /* Sélectionne celui qui a le plus de voisin proche = celui avec la plus petite somme de distance. */
            var minSum = localDistanceSumMap.Min(t => t.Value);
            var prochainVecteur = localDistanceSumMap.First(t => t.Value == minSum).Key;

            return prochainVecteur;
        }
    }
}
