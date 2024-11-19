using WebAPI.Repositories;
using WebAPI.Services;

namespace WebAPI.Strategies
{
    public class RuleBasedOnLastDigitStrategy : IImageSelectionStrategy
    {
        private readonly IImageRepository _repository;
        private readonly IExternalImageService _externalService;

        public RuleBasedOnLastDigitStrategy(IImageRepository repository, IExternalImageService externalService)
        {
            _repository = repository;
            _externalService = externalService;
        }
        public async Task<string> GetImageUrlAsync(string userId)
        {
            char lastChar = userId[^1];
            if (char.IsDigit(lastChar))
            {
                int lastDigit = lastChar - '0';
                if (lastDigit >= 6 && lastDigit <= 9)
                {
                    // Fetch image URL from external service
                    return await _externalService.GetImageUrlFromApiAsync(lastDigit);
                }
                else if (lastDigit >= 1 && lastDigit <= 5)
                {
                    return await _repository.GetImageUrlAsync(lastDigit);
                }
            }
            return null;
        }
    }
}
