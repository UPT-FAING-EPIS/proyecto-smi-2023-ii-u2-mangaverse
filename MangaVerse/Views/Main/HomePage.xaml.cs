using MangaVerse.Services.api;

namespace MangaVerse.Views
{
    public partial class HomePage : ContentPage
    {
        private HomeViewModel viewModel;
        private int currentIndex = 0;
        private TimeSpan carouselInterval = TimeSpan.FromSeconds(5); // Intervalo de 5 segundos

        public HomePage()
        {
        InitializeComponent();
        var mangaTopService = new MangaTop();
        viewModel = new HomeViewModel(mangaTopService);
        BindingContext = viewModel;
        StartCarouselAutoScroll();
            
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
