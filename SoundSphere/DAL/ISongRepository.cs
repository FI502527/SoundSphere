﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;

namespace DAL
{
    public interface ISongRepository
    {
        public SongDTO LoadSongById(int id);
        public List<SongDTO> LoadAllSongs();
        public bool AddSong(SongDTO song);
        public SongArtist GetSongArtist(int id);
        public SongGenre GetSongGenre(int id);
    }
}