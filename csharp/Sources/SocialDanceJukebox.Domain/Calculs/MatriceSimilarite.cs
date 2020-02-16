using System;
using System.Collections.Generic;
using SocialDanceJukebox.Domain.Dto;

namespace SocialDanceJukebox.Domain.Calculs
{
    public class MatriceSimilarite
    {
        private readonly Dictionary<Tuple<int, int>, decimal> _map = new Dictionary<Tuple<int, int>, decimal>();

        public decimal this [VecteurChanson x, VecteurChanson y]
        {
            get
            {
                return _map[new Tuple<int, int>(x.Id, y.Id)];
            }
            set
            {
                _map[new Tuple<int, int>(x.Id, y.Id)] = value;
            }
        }
    }
}
