using SocialDanceJukebox.Domain.Calculs.Contracts;
using SocialDanceJukebox.Domain.Dto;
using System.Linq;

namespace SocialDanceJukebox.Domain.Calculs
{
    public class ScoreCalculeur : IScoreCalculeur
    {
        private readonly IDistance _distance;

        public ScoreCalculeur(IDistance distance)
        {
            _distance = distance;
        }

        public decimal Calcule(CalculData data)
        {
            /* Calcule la distance maximale entre deux vecteurs. */
            var copy = data.Vecteurs.ToList();
            var distanceMax = data.Vecteurs.Max(a => copy.Max(b => _distance.Calcule(a, b)));

            /* Nombre de transition de chansons. */
            int nbTransitions = data.Vecteurs.Count - 1;

            decimal buffer = 0;
            var vecteursOrdonne = data.Vecteurs.OrderBy(v => v.Ordre).ToList();

            /* Parcourt les vecteurs ordonnés du 1er à l'avant dernier. */
            for (int rowIdx = 0; rowIdx < nbTransitions; rowIdx++)
            {
                /* Somme les distances avec le suivant. */
                var vecteurN = vecteursOrdonne[rowIdx];
                var vecteurN1 = vecteursOrdonne[rowIdx+1];
                buffer += _distance.Calcule(vecteurN, vecteurN1);
            }

            /* Normalise la somme des distance */
            buffer = buffer / (nbTransitions * distanceMax);

            return buffer;
        }
    }
}
