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
        /// Clé du tempo.
        /// </summary>
        public const int TempoKey = 1;

        /// <summary>
        /// Clé du genre.
        /// </summary>
        public const int GenreKey = 2;

        /// <summary>
        /// Clé du type.
        /// </summary>
        public const int TypeKey = 3;

        /// <summary>
        /// Clé de la fréquence.
        /// </summary>
        public const int FrequenceKey = 4;

        /// <summary>
        /// Chanson.
        /// </summary>
        public Chanson Chanson { get; set; }

        public int Id
        {
            get
            {
                return this.Chanson.Id;
            }
        }
    }
}
