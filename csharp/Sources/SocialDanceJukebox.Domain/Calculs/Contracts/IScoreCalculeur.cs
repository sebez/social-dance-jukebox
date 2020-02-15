using SocialDanceJukebox.Domain.Dto;

namespace SocialDanceJukebox.Domain.Calculs.Contracts
{
    public interface IScoreCalculeur
    {
        decimal Calcule(CalculData data);
    }
}
