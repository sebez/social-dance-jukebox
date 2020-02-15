using SocialDanceJukebox.Domain.Calculs.Contracts;
using SocialDanceJukebox.Domain.Dto;
using System;

namespace SocialDanceJukebox.Domain.Calculs
{
    public class TrieurAleatoire : ITrieur
    {
        public void Tri(CalculData data)
        {
            var random = new Random(DateTime.Now.Millisecond);
            foreach (var vecteur in data.Vecteurs)
            {
                vecteur.Ordre = random.Next(1, 40);
            }
        }
    }
}
