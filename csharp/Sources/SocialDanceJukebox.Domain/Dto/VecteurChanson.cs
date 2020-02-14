using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SocialDanceJukebox.Domain.Dto
{
    /// <summary>
    /// Vecteur représentant une chanson pour le calcul.
    /// </summary>
    [SuppressMessage("Naming", "CA1710:Identifiers should have correct suffix", Justification = "Non pertinent.")]
    public class VecteurChanson : Dictionary<int, decimal>
    {
        /// <summary>
        /// Chanson.
        /// </summary>
        public Chanson Chanson { get; set; }
    }
}
