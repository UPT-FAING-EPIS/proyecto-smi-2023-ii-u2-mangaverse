using System.Collections.ObjectModel;
using MangaVerse.Models;
using MangaVerse.Services.api;
using MangaVerse.ViewModels;

namespace MangaVerse
{
    public class DescubreViewModel : BaseViewModel
    {

        private readonly IMangaSearch _mangaSearch;
        public ObservableCollection<MangasSearch> SearchResults { get; set; } = new ObservableCollection<MangasSearch>();

        public DescubreViewModel(IMangaSearch searchService)
        {
            _mangaSearch = searchService;
        }
        public async Task SearchMangas(string keyword)
        {
            var searchResults = await _mangaSearch.Search(keyword);
            SearchResults.Clear();
            foreach (var result in searchResults)
            {
                SearchResults.Add(result);
            }
        }

    }
}
