using SocialDanceJukebox.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialDanceJukebox.Domain.Calculs
{
    public class VecteurNormalisateur
    {
        private readonly Dictionary<int, decimal> _poidsMap = new Dictionary<int, decimal>
        {
            [VecteurChanson.TempoKey] = 2,
            [VecteurChanson.GenreKey] = 1,
            [VecteurChanson.TypeKey] = 1,
            [VecteurChanson.FrequenceKey] = 1
        };

        public void Normalise(CalculData data)
        {
            /* Parcourt les champs */
            var fieldIdxList = data.Vecteurs.First().Keys.ToList();
            foreach (int fieldIdx in fieldIdxList)
            {
                /* Calcul les extrema */
                var minValue = data.Vecteurs.Min(x => x[fieldIdx]);
                var maxValue = data.Vecteurs.Max(x => x[fieldIdx]);

                /* Normalise la coordonnée, pondéré par le poids. */
                foreach (var vecteur in data.Vecteurs)
                {
                    vecteur[fieldIdx] = _poidsMap[fieldIdx] * (vecteur[fieldIdx] - minValue) / (maxValue - minValue);
                }
            }
        }
    }
}
