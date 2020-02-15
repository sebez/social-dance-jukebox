using System;
using System.Linq;
using SocialDanceJukebox.Domain.Calculs.Contracts;
using SocialDanceJukebox.Domain.Dto;

namespace SocialDanceJukebox.Domain.Calculs
{
    public class DistanceEuclidienne : IDistance
    {
        public decimal Calcule(VecteurChanson a, VecteurChanson b)
        {
            double buffer = 0;

            /* Parcourt les champs */
            var fieldIdxList = a.Keys.ToList();
            foreach (int fieldIdx in fieldIdxList)
            {
                buffer += Math.Pow( (double) (b[fieldIdx] - a[fieldIdx]), 2);
            }

            buffer = Math.Sqrt(buffer);

            return (decimal)buffer;
        }
    }
}
