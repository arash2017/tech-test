namespace WebAPI.Strategies
{
    public class RuleBasedOnVowelStrategy : IImageSelectionStrategy
    {
        public Task<string> GetImageUrlAsync(string userId)
        {
            if (userId.Any(c => "aeiou".Contains(char.ToLower(c))))
            {
                return Task.FromResult("https://api.dicebear.com/8.x/pixel-art/png?seed=vowel&size=150");
            }
            return Task.FromResult<string>(null);
        }
    }
}
