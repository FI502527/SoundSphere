using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ArtistRepository : IArtistRepository
    {
        public ArtistDTO LoadArtistById(int id)
        {
            Connection conn = new();
            using (SqlConnection sqlConnection = conn.GetConnection())
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM Artists WHERE id = {id};", sqlConnection);
                ArtistDTO artist = new ArtistDTO();
                sqlConnection.Open();
                SqlDataReader DataReader = command.ExecuteReader();
                if (DataReader.HasRows)
                {
                    while (DataReader.Read())
                    {
                        artist.Id = DataReader.GetInt32(0);
                        artist.Name = DataReader.GetString(1);
                    }
                }
                return artist;
            }
        }
        public List<ArtistDTO> LoadAllArtists()
        {
            Connection conn = new();
            using (SqlConnection sqlConnection = conn.GetConnection())
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM Artists;", sqlConnection);
                List<ArtistDTO> artists = new List<ArtistDTO>();
                sqlConnection.Open();
                SqlDataReader DataReader = command.ExecuteReader();
                if (DataReader.HasRows)
                {
                    while (DataReader.Read())
                    {
                        ArtistDTO artist = new ArtistDTO();
                        artist.Id = DataReader.GetInt32(0);
                        artist.Name = DataReader.GetString(1);
                        artists.Add(artist);
                    }
                }
                return artists;
            }
        }
    }
}
