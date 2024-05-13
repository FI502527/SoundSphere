using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IArtistRepository
    {
        public ArtistDTO LoadArtistById(int id);
        public List<ArtistDTO> LoadAllArtists();
    }
}
