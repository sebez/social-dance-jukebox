using System.Collections.Generic;

namespace SocialDanceJukebox.Domain.Dto
{
    public class Playlist
    {
        /// <summary>
        /// Titre de la playlist.
        /// </summary>
        public string Titre { get; set; }

        /// <summary>
        /// Liste des chansons.
        /// </summary>
        public ICollection<Chanson> Chansons { get; } = new List<Chanson>();

        /// <summary>
        /// Liste des vecteurs.
        /// </summary>
        public ICollection<VecteurChanson> Vecteurs { get; } = new List<VecteurChanson>();
    }
}
