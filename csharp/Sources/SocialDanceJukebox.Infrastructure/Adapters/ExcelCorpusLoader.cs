using SocialDanceJukebox.Domain.Dto;
using SocialDanceJukebox.Domain.Ports.Inbound;

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
            return new Playlist();
        }
    }
}
