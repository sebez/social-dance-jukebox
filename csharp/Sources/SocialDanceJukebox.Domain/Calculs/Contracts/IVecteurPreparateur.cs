using SocialDanceJukebox.Domain.Dto;

namespace SocialDanceJukebox.Domain.Calculs.Contracts
{
    public interface IVecteurPreparateur
    {
        /// <summary>
        /// Prépare un vecteur.
        /// </summary>
        /// <param name="data"></param>
        void Prepare(CalculData data);
    }
}
