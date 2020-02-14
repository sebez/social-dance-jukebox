using System;
using System.Collections.Generic;
using System.Text;

namespace SocialDanceJukebox.Domain.Dto
{
    public class CalculData
    {
        public IList<VecteurChanson> Vecteurs { get; } = new List<VecteurChanson>();
    }
}
