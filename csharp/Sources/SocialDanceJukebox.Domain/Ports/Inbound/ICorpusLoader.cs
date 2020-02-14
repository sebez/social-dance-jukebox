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
    }
}
