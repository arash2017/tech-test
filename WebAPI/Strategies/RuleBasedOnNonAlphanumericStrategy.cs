namespace WebAPI.Strategies
{
    public class RuleBasedOnNonAlphanumericStrategy : IImageSelectionStrategy
    {
        public Task<string> GetImageUrlAsync(string userId)
        {
            if (userId.Any(c => !char.IsLetterOrDigit(c)))
            {
                var random = new Random();
                int randomSeed = random.Next(1, 6); // Generates a number between 1 and 5
                return Task.FromResult($"https://api.dicebear.com/8.x/pixel-art/png?seed={randomSeed}&size=150");
            }
            return Task.FromResult<string>(null);
        }
    }
}
