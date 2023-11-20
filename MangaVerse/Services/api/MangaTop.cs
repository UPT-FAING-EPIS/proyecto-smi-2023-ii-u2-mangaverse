using MangaVerse.Models;
using System.Text.Json;

namespace MangaVerse.Services.api
{
    public class MangaTop : IMangaTop
    {
        private string urlApi = "https://manga-apiv1.vercel.app/api/popular";

        public async Task<List<MangasTop>> Get()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(urlApi);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();

                // Deserializar la respuesta directamente en una lista de MangasResponse
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Opcional, para que coincida con el nombre de las propiedades en CamelCase
                };

                var data = JsonSerializer.Deserialize<List<MangasTop>>(responseBody, options);
                if (data != null)
                {
                    return data;
                }
            }

            // Manejar errores aquí
            return new List<MangasTop>();
        }
    }
}