namespace MangaVerse.Models
{
    public class MangasTop
    {
        public int id { get; set; }
        public string rank { get; set; }
        public string title { get; set; }
        public string slug { get; set; }
        public string cover { get; set; }
        public float rating { get; set; }
        public string[] langs { get; set; }
        public object chapters { get; set; }
        public object volumes { get; set; }
    }
}