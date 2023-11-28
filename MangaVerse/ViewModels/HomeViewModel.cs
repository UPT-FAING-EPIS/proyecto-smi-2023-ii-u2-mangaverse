using System.Collections.ObjectModel;
using System.ComponentModel;
using MangaVerse.Models;
using MangaVerse.Services.api;
using MangaVerse.ViewModels;

namespace MangaVerse
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<CarouselItem> ImageItems { get; set; }
        public ObservableCollection<Manga> Mangas { get; set; }
        private readonly IMangaTop _mangaTop;
        public ObservableCollection<MangasTop> TopMangas { get; set; } = new ObservableCollection<MangasTop>();


        public HomeViewModel(IMangaTop mangaTopService)
        {
            ImageItems = new ObservableCollection<CarouselItem>();
            Mangas = new ObservableCollection<Manga>();
            _mangaTop = mangaTopService;
            LoadImages();
            LoadMangas();
            LoadTopMangas();
        }
        private async void LoadTopMangas()
        {
            var data = await _mangaTop.Get();
            foreach (var manga in data)
            {
                TopMangas.Add(manga);
            }
        }
        private void LoadImages()
        {
            ImageItems.Add(new CarouselItem { ImageCarousel = "borutoc.jpg" });
            ImageItems.Add(new CarouselItem { ImageCarousel = "one.jpg" });
            ImageItems.Add(new CarouselItem { ImageCarousel = "jujutsu.jpg" });
            ImageItems.Add(new CarouselItem { ImageCarousel = "bluelock.jpg" });
            ImageItems.Add(new CarouselItem { ImageCarousel = "man.jpg" });
        }

        private void LoadMangas()
        {
            AddManga("diasporaiser.jpg", "Diasporaiser", "Ondori Nukui", 2);
            AddManga("tsurukoreturnsthefavor.jpg", "Tsuruko Returns the Favor", "Yokoyama Hidari", 2);
            AddManga("wildstrawberry.jpg", "Wild Strawberry", "Ire Yonemoto", 2);
            AddManga("skeletondouble.jpg", "Skeleton Double", "Tokaku Kondo", 2);
            AddManga("tokyoghoulre.jpg", "Tokyo Ghoul: re", "Sui Ishida", 2);
            AddManga("boruto.jpg", "BORUTO - TWO BLUE VORTEX", "MASASHI KISHIMOTO / MIKIO IKEMOTO", 2);
        }

        private void AddManga(string imagePath, string title, string author, int chapterCount)
        {
            var manga = new Manga
            {
                ImagePath = imagePath,
                Title = title,
                Author = author,
                Chapters = GenerateChapters(chapterCount)
            };

            Mangas.Add(manga);
        }

        private ObservableCollection<Chapter> GenerateChapters(int count)
        {
            var chapters = new ObservableCollection<Chapter>();
            for (int i = 1; i <= count; i++)
            {
                chapters.Add(new Chapter { Title = $"Capítulo {i}", Number = i });
            }
            return chapters;
        }
    }
}
