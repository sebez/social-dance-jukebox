namespace SocialDanceJukebox.Domain.Dto
{
    /// <summary>
    /// Représente une chanson.
    /// </summary>
    public class Chanson
    {
        /// <summary>
        /// ID de la chanson.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Titre de la chanson.
        /// </summary>
        public string Titre { get; set; }

        /// <summary>
        /// Artiste de la chanson.
        /// </summary>
        public string Artiste { get; set; }

        /// <summary>
        /// Tempo de la chanson.
        /// </summary>
        public int Tempo { get; set; }

        /// <summary>
        /// Genre de la chanson.
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Type de la chanson.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Genre de la chanson.
        /// </summary>
        public string Frequence { get; set; }

        /// <summary>
        /// Ordre de la chanson.
        /// </summary>
        public int Ordre { get; set; }
    }
}
