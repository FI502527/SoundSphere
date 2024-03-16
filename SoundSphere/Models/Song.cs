namespace Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public void SetDetails(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}