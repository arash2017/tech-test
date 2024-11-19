namespace WebAPI.Repositories
{
    public interface IImageRepository
    {
        Task<string> GetImageUrlAsync(int id);
    }
}
