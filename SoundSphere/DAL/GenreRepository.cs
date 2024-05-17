using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GenreRepository : IGenreRepository
    {
        public GenreDTO  LoadGenreById(int songId)
        {
            Connection conn = new();
            using (SqlConnection sqlConnection = conn.GetConnection())
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM Genres WHERE id = {songId};", sqlConnection);
                GenreDTO genre = new GenreDTO();
                sqlConnection.Open();
                SqlDataReader DataReader = command.ExecuteReader();
                if (DataReader.HasRows)
                {
                    while (DataReader.Read())
                    {
                        genre.Id = DataReader.GetInt32(0);
                        genre.Name = DataReader.GetString(1);
                    }
                }
                return genre;
            }
        }
    }
}
