using MangaVerse.Models;
using MangaVerse.Services.api;

namespace MangaVerse.Views
{
    public partial class DescubrePage : ContentPage
    {
        private readonly IMangaSearch _mangaSearch;
        private DescubreViewModel viewModel;

        public DescubrePage(IMangaSearch searchService)
        {
            InitializeComponent();
            viewModel = new DescubreViewModel();
            BindingContext = viewModel;
            _mangaSearch = searchService;
        }
        private async void OnSearchClicked(object sender, EventArgs e)
        {
            string keyword = searchEntry.Text;

            // Llama a tu servicio de búsqueda con la palabra clave
            List<MangasSearch> searchResults = await _mangaSearch.Search(keyword);

            // Actualiza la colección en tu CollectionView con los resultados de la búsqueda
            collectionViewMangas.ItemsSource = searchResults;
        }

    }
}