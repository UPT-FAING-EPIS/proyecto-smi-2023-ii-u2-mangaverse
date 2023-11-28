using MangaVerse.Models;

namespace MangaVerse.Services.api
{
    public interface IMangaSearch
    {
        public Task<List<MangasSearch>> Search(string keyword);
    }
}