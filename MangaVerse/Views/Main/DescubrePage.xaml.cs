using MangaVerse.Models;
using MangaVerse.Services.api;

namespace MangaVerse.Views
{
    public partial class DescubrePage : ContentPage
    {

        private DescubreViewModel viewModel;

        public DescubrePage(IMangaSearch searchService)
        {
            InitializeComponent();
            viewModel = new DescubreViewModel(searchService);
            BindingContext = viewModel;

        }
        private async void OnSearchClicked(object sender, EventArgs e)
        {
            string keyword = searchEntry.Text;
            await viewModel.SearchMangas(keyword);
            collectionViewMangas.ItemsSource = viewModel.SearchResults;
        }

    }
}