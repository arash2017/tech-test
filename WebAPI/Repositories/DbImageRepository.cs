using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace WebAPI.Repositories
{
    public class DbImageRepository : IImageRepository
    {
         private readonly AppDbContext _context;
        public DbImageRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<string> GetImageUrlAsync(int id)
        {
            var image = await _context.Images.FirstOrDefaultAsync(i => i.Id == id);
            return image?.Url;
        }
    }
}
