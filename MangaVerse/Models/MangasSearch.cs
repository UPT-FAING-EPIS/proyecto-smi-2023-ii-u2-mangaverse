namespace MangaVerse.Models
{
    public class MangasSearch
    {
        
        public int Id { get; set; }
        public int MangaId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Cover { get; set; }
        public List<string> Langs { get; set; }
        public Dictionary<string, object> Chapters { get; set; }
    }
}