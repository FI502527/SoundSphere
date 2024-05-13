namespace SoundSphere.Models
{
    public class SongViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ArtistViewModel Artist { get; set; }
    }
}
