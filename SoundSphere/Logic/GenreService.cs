using DAL;
using DAL.DTO;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class GenreService
    {
        private readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public GenreModel LoadGenreById(int id)
        {
            GenreDTO genreDTO = _genreRepository.LoadGenreById(id);
            GenreModel genre = new GenreModel();
            genre.Id = genreDTO.Id;
            genre.Name = genreDTO.Name;
            return genre;
        }
    }
}
