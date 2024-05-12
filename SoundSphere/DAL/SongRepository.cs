﻿using System;
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
            List<SongDTO> allSongs = new List<SongDTO>();
            sqlConnection.Open();
            SqlDataReader DataReader = command.ExecuteReader();
            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    SongDTO song = new SongDTO();
                    song.Id = DataReader.GetInt32(0);
                    song.Title = DataReader.GetString(1);
                    allSongs.Add(song);
                }
            }
            DataReader.Close();
            sqlConnection.Close();
            return allSongs;
        }
    }
}