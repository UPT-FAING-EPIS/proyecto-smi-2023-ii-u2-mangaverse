using System.Collections.ObjectModel;

namespace MangaVerse.Models
{
    public class Manga
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public ObservableCollection<Chapter> Chapters { get; set; }
        public string ImagePath { get; set; }
    }

    public class Chapter
    {
        public string Title { get; set; }
        public int Number { get; set; }
    }
}
