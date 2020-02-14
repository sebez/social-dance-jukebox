using SocialDanceJukebox.Domain.Dto;

namespace SocialDanceJukebox.Domain.Ports.Inbound
{
    /// <summary>
    /// Chargeur de corpus de chanson.
    /// </summary>
    public interface ICorpusLoader
    {
        /// <summary>
        /// Charge la playlist à trier.
        /// </summary>
        /// <returns></returns>
        Playlist LoadPlaylist();

        /// <summary>
        /// Enregistre la playlist ordonné.
        /// </summary>
        /// <param name="playlist"></param>
        void SavePlayList(Playlist playlist);
    }
}
