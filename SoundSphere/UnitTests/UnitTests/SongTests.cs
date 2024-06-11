using Logic.Models;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.TestDAL;
using DAL.DTO;

namespace UnitTests.UnitTests
{
    [TestClass]
    public class SongTests
    {
        [TestMethod]
        public void GetSongByIdTest()
        {
            //Act
            int id = 1;
            TestSongRepository repository = new TestSongRepository();
            TestArtistRepository artistRepository = new TestArtistRepository();
            TestGenreRepository genreRepository = new TestGenreRepository();
            SongService songService = new SongService(repository, artistRepository, genreRepository);
            SongModel expectedSong = new SongModel();
            expectedSong.Id = 1;
            expectedSong.Title = "Europapa";

            //Arrange
            SongModel song = songService.LoadSongById(id);

            //Assert
            Assert.AreEqual(expectedSong.Id, song.Id);
            Assert.AreEqual(expectedSong.Title, song.Title);
        }
        [TestMethod]
        public void GetAllSongsTest()
        {
            //Act
            TestSongRepository repository = new TestSongRepository();
            TestArtistRepository artistRepository = new TestArtistRepository();
            TestGenreRepository genreRepository = new TestGenreRepository();
            SongService songService = new SongService(repository, artistRepository, genreRepository);
            int expectedSongsAmount = 3;

            //Arrange
            List<SongModel> songs = songService.LoadAllSongs();

            //Assert
            Assert.AreEqual(expectedSongsAmount, songs.Count);
        }
    }
}
