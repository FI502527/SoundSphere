using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IGenreRepository
    {
        public SongGenre LoadGenreById(int songId);
    }
}
