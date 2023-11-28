using MangaVerse.Models;

namespace MangaVerse.Services.api
{
    public interface IMangaTop
    {
        public Task<List<MangasTop>> Get();
    }
}