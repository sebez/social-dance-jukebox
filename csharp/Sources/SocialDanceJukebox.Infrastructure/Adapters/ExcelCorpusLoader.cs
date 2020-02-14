using ClosedXML.Excel;
using SocialDanceJukebox.Domain.Dto;
using SocialDanceJukebox.Domain.Ports.Inbound;
using System.Linq;

namespace SocialDanceJukebox.Infrastructure.Adapters
{
    public class ExcelCorpusLoader : ICorpusLoader
    {
        private readonly ExcelCorpusLoaderConfig _config;

        public ExcelCorpusLoader(ExcelCorpusLoaderConfig config)
        {
            _config = config;
        }

        public Playlist LoadPlaylist()
        {
            var wb = new XLWorkbook(_config.CheminFichier);

            var ws = wb.Worksheet("Data");
            var table = ws.Table("ListeChansons");

            var playlist = new Playlist();
            foreach (var row in table.DataRange.Rows())
            {
                var chanson = new Chanson();

                chanson.Id = row.Field("ID").GetValue<int>();
                chanson.Titre = row.Field("Nom").GetString();
                chanson.Artiste = row.Field("Artiste").GetString();
                chanson.Tempo = (int)row.Field("Tempo").GetDouble();
                chanson.Type = row.Field("Type").GetString();
                chanson.Genre = row.Field("Genre").GetString();
                chanson.Frequence = row.Field("Fréquence").GetString();

                playlist.Chansons.Add(chanson);
            }

            return playlist;
        }

        public void SavePlayList(Playlist playlist)
        {
            var wb = new XLWorkbook(_config.CheminFichier);

            var ws = wb.Worksheet("Data");
            var table = ws.Table("ListeChansons");

            foreach (var row in table.DataRange.Rows())
            {
                var currentID = row.Field("ID").GetValue<int>();
                var chanson = playlist.Chansons.Single(c => c.Id == currentID);
                row.Field("Ordre").SetValue<int>(chanson.Ordre);
            }

            wb.Save();
        }
    }
}
