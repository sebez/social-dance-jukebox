using System;
using System.Collections.Generic;
using System.Text;
using SocialDanceJukebox.Domain.Dto;

namespace SocialDanceJukebox.Domain.Calculs.Contracts
{
    public interface IProchainVecteurSelecteur
    {
        VecteurChanson Selectionne(VecteurChanson vecteurPrecedent, List<VecteurChanson> vecteursRestant, CalculData data);
    }
}
