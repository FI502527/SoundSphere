using DAL;
using DAL.DTO;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ArtistService
    {
        private readonly IArtistRepository _repository;
        public ArtistService(IArtistRepository repository)
        {
            _repository = repository;
        }
        public List<ArtistModel> LoadAllArtists()
        {
            List<ArtistDTO> artistDTOs = _repository.LoadAllArtists();
            List<ArtistModel> artists = new List<ArtistModel>();
            foreach(ArtistDTO artistDTO in artistDTOs)
            {
                ArtistModel artist = new ArtistModel();
                artist.Id = artistDTO.Id;
                artist.Name = artistDTO.Name;
                artists.Add(artist);
            }
            return artists;
        }
        public ArtistModel LoadArtistById(int id)
        {
            ArtistDTO artistDTO = _repository.LoadArtistById(id);
            ArtistModel artistModel = new ArtistModel();
            artistModel.Id = artistDTO.Id;
            artistModel.Name = artistDTO.Name;
            return artistModel;
        }
    }
}
