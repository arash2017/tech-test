namespace WebAPI.Strategies
{
    public interface IImageSelectionStrategy
    {
        Task<string> GetImageUrlAsync(string userId);
    }
}
