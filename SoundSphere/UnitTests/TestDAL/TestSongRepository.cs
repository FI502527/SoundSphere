using DAL;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.TestDAL
{
    public class TestSongRepository : ISongRepository
    {
        public SongDTO LoadSongById(int id)
        {
            SongDTO song = new SongDTO();
            song.Id = id;
            song.Title = "Europapa";
            return song;
        }
        public List<SongDTO> LoadAllSongs()
        {
            SongDTO song1 = new SongDTO();
            SongDTO song2 = new SongDTO();
            SongDTO song3 = new SongDTO();
            List<SongDTO> songs = [song1, song2, song3];
            return songs;
        }
        public bool AddSong(SongDTO song)
        {
            return true;
        }
        public SongArtist GetSongArtist(int id)
        {
            SongArtist song = new SongArtist();
            song.Artist_Id = 5;
            song.Song_Id = id;
            return song;
        }
        public SongGenre GetSongGenre(int id)
        {
            SongGenre song = new SongGenre();
            song.Song_Id = id;
            song.Genre_Id = 4;
            return song;
        }
    }
}
