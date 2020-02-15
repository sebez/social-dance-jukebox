using System.Collections.Generic;
using SocialDanceJukebox.Domain.Calculs;

namespace SocialDanceJukebox.Domain.Dto
{
    public class CalculData
    {
        public IList<VecteurChanson> Vecteurs { get; } = new List<VecteurChanson>();

        public MatriceSimilarite MatriceSimilarite { get; set; }
    }
}
