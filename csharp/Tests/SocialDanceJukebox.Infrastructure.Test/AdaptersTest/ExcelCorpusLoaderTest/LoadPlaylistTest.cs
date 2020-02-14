using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialDanceJukebox.Infrastructure.Adapters;

namespace SocialDanceJukebox.Infrastructure.Test.AdaptersTest.ExcelCorpusLoaderTest
{
    [TestClass]
    public class LoadPlaylistTest
    {
        [TestMethod]
        public void Check()
        {
            // Arrange
            var config = new ExcelCorpusLoaderConfig
            {
                // TODO rendre relatif.
                CheminFichier = @"C:\Data\ProjetsGit\social-dance-jukebox\csharp\Tests\SocialDanceJukebox.Infrastructure.Test\Resources\DataChansons.xlsx"
            };
            var loader = new ExcelCorpusLoader(config);

            // Act
            var result = loader.LoadPlaylist();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(40, result.Chansons.Count);
        }
    }
}
