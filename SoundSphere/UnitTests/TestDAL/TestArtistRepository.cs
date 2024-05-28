using DAL;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.TestDAL
{
    public class TestArtistRepository : IArtistRepository
    {
        public ArtistDTO LoadArtistById(int id)
        {
            ArtistDTO artist = new ArtistDTO();
            artist.Id = id;
            artist.Name = "Joost Klein";
            return artist;
        }
        public List<ArtistDTO> LoadAllArtists()
        {
            ArtistDTO artist = new ArtistDTO();
            artist.Id = 1;
            artist.Name = "Joost Klein";
            ArtistDTO artist2 = new ArtistDTO();
            artist.Id = 2;
            artist.Name = "Micheal Jackson";
            ArtistDTO artist3 = new ArtistDTO();
            artist.Id = 3;
            artist.Name = "Abba";
            List<ArtistDTO> artists = new List<ArtistDTO>();
            artists.Add(artist);
            artists.Add(artist2);
            artists.Add(artist3);
            return artists;
        }
    }
}
