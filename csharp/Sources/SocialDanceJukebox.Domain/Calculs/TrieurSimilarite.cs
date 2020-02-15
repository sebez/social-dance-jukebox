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
        private readonly IProchainVecteurSelecteur _prochainVecteurSelecteur;

        public TrieurSimilarite(IDistance distance, IProchainVecteurSelecteur prochainVecteurSelecteur)
        {
            _distance = distance;
            _prochainVecteurSelecteur = prochainVecteurSelecteur;
        }

        public void Tri(CalculData data)
        {
            var vecteursRestant = data.Vecteurs.ToList();

            /* Choisit le premier vecteur. */
            var premierVecteur = ChoisitPremierVecteur(data);
            premierVecteur.Ordre = 1;
            vecteursRestant.Remove(premierVecteur);

            var vecteurPrecedent = premierVecteur;

            /* Cherche l'ordre n itérativement. */
            var dim = data.Vecteurs.Count;
            for (int n = 2; n <= dim; n++)
            {
                var prochainVecteur = _prochainVecteurSelecteur.Selectionne(vecteurPrecedent, vecteursRestant, data);

                /* Ajoute le prochain vecteur. */
                prochainVecteur.Ordre = n;
                vecteursRestant.Remove(prochainVecteur);
            }
        }

        private static VecteurChanson ChoisitPremierVecteur(CalculData data)
        {
            return data.Vecteurs.First();
        }
    }
}
