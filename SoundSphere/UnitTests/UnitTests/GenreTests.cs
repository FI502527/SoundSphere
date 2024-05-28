using Logic;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.TestDAL;

namespace UnitTests.UnitTests
{
    [TestClass]
    public class GenreTests
    {
        [TestMethod]
        public void GetGenreByIdTest()
        {
            //Act
            int id = 1;
            TestGenreRepository repository = new TestGenreRepository();
            GenreService genreService = new GenreService(repository);
            GenreModel expectedGenre = new GenreModel();
            expectedGenre.Id = 1;
            expectedGenre.Name = "Pop";

            //Arrange
            GenreModel genre = genreService.LoadGenreById(id);

            //Assert
            Assert.AreEqual(expectedGenre.Id, genre.Id);
            Assert.AreEqual(expectedGenre.Name, genre.Name);
        }
    }
}
