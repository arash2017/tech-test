namespace WebAPI.Services
{
    public interface IExternalImageService
    {
             Task<string> GetImageUrlFromApiAsync(int lastDigit);
        
    }
}
