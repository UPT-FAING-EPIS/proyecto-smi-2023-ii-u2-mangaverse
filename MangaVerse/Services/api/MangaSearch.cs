    using MangaVerse.Models;
    using System.Text.Json;

namespace MangaVerse.Services.api
{
public class MangaSearch : IMangaSearch
        {
            private string urlApi = "https://manga-apiv1.vercel.app/api/search";

            public async Task<List<MangasSearch>> Search(string keyword)
            {
                var client = new HttpClient();
                var requestUrl = $"{urlApi}?keyword={keyword}";
                var response = await client.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions         
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var data = JsonSerializer.Deserialize<List<MangasSearch>>(responseBody, options);
                    if (data != null)
                    {
                        return data;
                    }
                }

                // Manejar errores aquí
                return new List<MangasSearch>();
            }
        }
}