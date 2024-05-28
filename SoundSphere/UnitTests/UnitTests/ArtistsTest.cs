using DAL.DTO;
using Logic;
using Logic.Models;
using UnitTests.TestDAL;

namespace UnitTests.UnitTests
{
    [TestClass]
    public class ArtistsTest
    {
        [TestMethod]
        public void GetArtistByIdTest()
        {
            //Act
            int id = 1;
            TestArtistRepository repository = new TestArtistRepository();
            ArtistService artistService = new ArtistService(repository);
            ArtistModel expectedArtist = new ArtistModel();
            expectedArtist.Id = 1;
            expectedArtist.Name = "Joost Klein";

            //Arrange
            ArtistModel artistModel = artistService.LoadArtistById(id);

            //Assert
            Assert.AreEqual(expectedArtist.Id, artistModel.Id);
            Assert.AreEqual(expectedArtist.Name, artistModel.Name);
        }
        [TestMethod]
        public void GetAllArtistsTest()
        {
            //Act
            TestArtistRepository repository = new TestArtistRepository();
            ArtistService artistService = new ArtistService(repository);
            int expectedArtists = 3;

            //Arrange
            List<ArtistModel> artists = artistService.LoadAllArtists();

            //Assert
            Assert.AreEqual(expectedArtists, artists.Count());
        }
    }
}