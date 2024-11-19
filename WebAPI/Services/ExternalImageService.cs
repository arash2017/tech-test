using System.Text.Json;

namespace WebAPI.Services
{
    public class ExternalImageService : IExternalImageService
    {
        private readonly HttpClient _httpClient;

        public ExternalImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetImageUrlFromApiAsync(int lastDigit)
        {
            var apiUrl = $"https://my-json-server.typicode.com/ck-pacificdev/tech-test/images/{lastDigit}";

            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var imageObject = JsonSerializer.Deserialize<ImageResponse>(json);

                return imageObject?.url; // Return the URL if parsing succeeds
            }

            return null; // Return null if the API call fails
        }

        private class ImageResponse
        {
            public int id { get; set; }
            public string url { get; set; }
        }
    }
}
