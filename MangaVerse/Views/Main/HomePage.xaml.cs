using MangaVerse.Services.api;

namespace MangaVerse.Views
{
    public partial class HomePage : ContentPage
    {
        private HomeViewModel viewModel;
        private int currentIndex = 0;
        private TimeSpan carouselInterval = TimeSpan.FromSeconds(5); // Intervalo de 5 segundos
        private readonly IMangaTop _mangaTop;

        public HomePage(IMangaTop service)
        {
            InitializeComponent();
            viewModel = new HomeViewModel();
            BindingContext = viewModel;
            StartCarouselAutoScroll();
            _mangaTop = service;
            LoadTopMangas();
            
        }
        private async void LoadTopMangas()
        {

            var data = await _mangaTop.Get();
            collectionViewTop.ItemsSource = data;

        }

        private async void StartCarouselAutoScroll()
        {
            while (true)
            {
                await Task.Delay(carouselInterval);
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    // Cambia automáticamente al siguiente elemento del carrusel
                    currentIndex = (currentIndex + 1) % viewModel.ImageItems.Count;
                    carouselView.Position = currentIndex;
                });
            }
        }
        
    }
}
