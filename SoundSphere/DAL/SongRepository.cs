using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class SongRepository
    {
        public Song LoadSongById(int id)
        {
            Connection conn = new();
            SqlConnection sqlConnection = conn.GetConnection();
            SqlCommand command = new SqlCommand($"SELECT * FROM Songs WHERE id = {id};", sqlConnection);
            Song song = new Song();
            sqlConnection.Open();
            SqlDataReader DataReader = command.ExecuteReader();
            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    song.SetDetails(DataReader.GetInt32(0), DataReader.GetString(1));
                }
            }
            DataReader.Close();
            sqlConnection.Close();
            return song;
        }
        public List<Song> LoadAllSongs()
        {
            Connection conn = new();
            SqlConnection sqlConnection = conn.GetConnection();
            SqlCommand command = new SqlCommand($"SELECT * FROM Songs;", sqlConnection);
            List<Song> songs = new List<Song>();
            sqlConnection.Open();
            SqlDataReader DataReader = command.ExecuteReader();
            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    Song song = new Song();
                    song.SetDetails(DataReader.GetInt32(0), DataReader.GetString(1));
                    songs.Add(song);
                }
            }
            DataReader.Close();
            sqlConnection.Close();
            return songs;
        }
    }
}
