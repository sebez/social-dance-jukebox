using SocialDanceJukebox.Domain.Dto;
using System;
using System.Collections.Generic;

namespace SocialDanceJukebox.Domain.Calculs
{
    public class ChansonConvertisseur
    {
        private readonly Dictionary<string, int> _genreMap = new Dictionary<string, int>
        {
            ["Oldie"] = 1,
            ["Oldie Cover"] = 2,
            ["80s"] = 3,
            ["Modern Cover"] = 4,
            ["Modern"] = 5
        };

        private readonly Dictionary<string, int> _typeMap = new Dictionary<string, int>
        {
            ["Rock"] = 1,
            ["Pop"] = 2,
            ["Français"] = 3,
            ["Disney"] = 4,
            ["Swing"] = 5
        };

        private readonly Dictionary<string, int> _frequenceMap = new Dictionary<string, int>
        {
            ["Standard"] = 1,
            ["Rare"] = 2
        };


        public VecteurChanson CalculVecteurChanson(Chanson chanson)
        {
            if(chanson == null)
            {
                throw new ArgumentNullException(nameof(chanson));
            }

            var vecteur = new VecteurChanson { Chanson = chanson };

            vecteur[VecteurChanson.TempoKey] = chanson.Tempo ;
            vecteur[VecteurChanson.GenreKey] = _genreMap[chanson.Genre];
            vecteur[VecteurChanson.TypeKey] = _typeMap[chanson.Type];
            vecteur[VecteurChanson.FrequenceKey] = _frequenceMap[chanson.Frequence];

            return vecteur;
        }
    }
}
