using SocialDanceJukebox.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialDanceJukebox.Domain.Calculs.Contracts
{
    public interface IDistance
    {
        /// <summary>
        /// Calcule la distance entre deux vecteurs.
        /// </summary>
        /// <param name="a">Vecteur a.</param>
        /// <param name="b">Vecteur b.</param>
        /// <returns>Distance.</returns>
        decimal Calcule(VecteurChanson a, VecteurChanson b);
    }
}
