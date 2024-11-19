using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class JsonImageRepository : IImageRepository
    {
        private readonly string _filePath;

        public JsonImageRepository(string filePath)
        {
            _filePath = filePath;
        }
        public async Task<string> GetImageUrlAsync(int id)
        {
            if (!File.Exists(_filePath)) return null;
            var jsonContent = await File.ReadAllTextAsync(_filePath);
            var images = JsonSerializer.Deserialize<Image[]>(jsonContent);

            return images?.FirstOrDefault(i => i.Id == id)?.Url;

        }
    }
}
