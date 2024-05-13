using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;

namespace DAL
{
    public class SongRepository : ISongRepository
    {
        public SongDTO LoadSongById(int id)
        {
            Connection conn = new();
            SqlConnection sqlConnection = conn.GetConnection();
            SqlCommand command = new SqlCommand($"SELECT * FROM Songs WHERE id = {id};", sqlConnection);
			SongDTO song = new SongDTO();
            sqlConnection.Open();
            SqlDataReader DataReader = command.ExecuteReader();
            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
					song.Id = DataReader.GetInt32(0);
					song.Title = DataReader.GetString(1);
				}
            }
            DataReader.Close();
            sqlConnection.Close();
            return song;
        }
        public List<SongDTO> LoadAllSongs()
        {
            Connection conn = new();
            SqlConnection sqlConnection = conn.GetConnection();
            SqlCommand command = new SqlCommand($"SELECT * FROM Songs;", sqlConnection);
            List<SongDTO> songs = new List<SongDTO>();
            sqlConnection.Open();
            SqlDataReader DataReader = command.ExecuteReader();
            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
					SongDTO song = new SongDTO();
                    song.Id = DataReader.GetInt32(0);
                    song.Title = DataReader.GetString(1);
                    songs.Add(song);
                }
            }
            DataReader.Close();
            sqlConnection.Close();
            return songs;
        }
        public bool AddSong(SongDTO song)
        {
            Connection conn = new();
            using (SqlConnection sqlConnection = conn.GetConnection())
            {

                SqlCommand command = new SqlCommand($"INSERT INTO Songs (title) VALUES (\'{song.Title}\')", sqlConnection);
                command.Connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }
        public SongArtist GetSongArtist(int songId)
        {
            Connection conn = new();
            using (SqlConnection sqlConnection = conn.GetConnection())
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM SongArtist WHERE song_id = {songId};", sqlConnection);
                SongArtist songArtist = new SongArtist();
                command.Connection.Open();
                SqlDataReader DataReader = command.ExecuteReader();
                if (DataReader.HasRows)
                {
                    while (DataReader.Read())
                    {
                        songArtist.Song_Id = DataReader.GetInt32(0);
                        songArtist.Artist_Id = DataReader.GetInt32(1);
                    }
                }
                return songArtist;
            }
        }
    }
}
