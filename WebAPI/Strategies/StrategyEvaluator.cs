namespace WebAPI.Strategies
{
    public class StrategyEvaluator
    {
        private readonly IEnumerable<IImageSelectionStrategy> _strategies;

        public StrategyEvaluator(IEnumerable<IImageSelectionStrategy> strategies)
        {
            _strategies = strategies;
        }

        public async Task<string> EvaluateAsync(string userId)
        {
            foreach (var strategy in _strategies)
            {
                var result = await strategy.GetImageUrlAsync(userId);
                if (result != null) return result;
            }

            return "https://api.dicebear.com/8.x/pixel-art/png?seed=default&size=150";
        }
    }
}
