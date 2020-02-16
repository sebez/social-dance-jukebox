using System.Linq;
using SocialDanceJukebox.Domain.Calculs.Contracts;
using SocialDanceJukebox.Domain.Dto;

namespace SocialDanceJukebox.Domain.Calculs
{
    public class MatriceSimilariteCalculateur
    {
        private readonly IDistance _distance;

        public MatriceSimilariteCalculateur(IDistance distance)
        {
            _distance = distance;
        }

        public void CalculeMatriceSimilarite(CalculData data)
        {
            var dim = data.Vecteurs.Count;
            var axeX = data.Vecteurs.ToList();
            var axeY = data.Vecteurs.ToList();
            var matriceSimilarite = new MatriceSimilarite();

            for (int x = 1; x <= dim; x++)
            {
                for (int y = 1; y <= dim; y++)
                {
                    var vectX = axeX[x - 1];
                    var vectY = axeY[y - 1];
                    matriceSimilarite[vectX, vectY] = _distance.Calcule(vectX, vectY);
                }
            }

            data.MatriceSimilarite = matriceSimilarite;
        }
    }
}
