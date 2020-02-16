using System;
using System.Linq;
using SocialDanceJukebox.Domain.Calculs.Contracts;
using SocialDanceJukebox.Domain.Dto;

namespace SocialDanceJukebox.Domain.Calculs
{
    /// <summary>
    /// Distance se basant sur la somme des différences binaires.
    /// Pour chaque composante du vecteur, la distance vaut 0 si c'est égale, 1 sinon.
    /// </summary>
    public class DistanceBinaire : IDistance
    {
        private const decimal SeuilDeltaTempo = 5m;

        public decimal Calcule(VecteurChanson a, VecteurChanson b)
        {
            decimal buffer = 0;

            /* Parcourt les champs */
            var fieldIdxList = a.Keys.ToList();
            foreach (int fieldIdx in fieldIdxList)
            {
                /* Ajoute la distance : 0 ou 1. */
                buffer += CalculeDistance(fieldIdx, a[fieldIdx], b[fieldIdx]);
            }

            return buffer;
        }

        private decimal CalculeDistance(int fieldIdx, decimal valueA, decimal valueB)
        {
            switch (fieldIdx)
            {
                case VecteurChanson.TempoKey:
                    return ComparaisonTempo(valueA, valueB);
                default:
                    return ComparaisonDelta(valueA, valueB);
            }
        }

        private static decimal ComparaisonTempo(decimal v1, decimal v2)
        {
            return
                   Math.Abs(v1 - v2) > SeuilDeltaTempo ?
                   1 :
                   0;
        }

        private static decimal ComparaisonDelta(decimal v1, decimal v2)
        {
            return
                   Math.Abs(v1 - v2) > 0.1m ?
                   1 :
                   0;
        }
    }
}
