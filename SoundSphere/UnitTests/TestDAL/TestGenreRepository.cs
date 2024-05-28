using DAL;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.TestDAL
{
    public class TestGenreRepository : IGenreRepository
    {
        public GenreDTO LoadGenreById(int songId)
        {
            GenreDTO genre = new GenreDTO();
            genre.Id = 1;
            genre.Name = "Pop";
            return genre;
        }
    }
}
