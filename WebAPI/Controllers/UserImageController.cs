using Microsoft.AspNetCore.Mvc;
using WebAPI.Strategies;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("avatar")]
    public class UserImageController : ControllerBase
    {
        private readonly StrategyEvaluator _strategyEvaluator;

        public UserImageController(StrategyEvaluator strategyEvaluator)
        {
            _strategyEvaluator = strategyEvaluator;
        }

        [HttpGet]
        public async Task<IActionResult> GetImage(string userIdentifier)
        {
            var imageUrl = await _strategyEvaluator.EvaluateAsync(userIdentifier);
            return Ok(new { imageUrl });
        }
    }
}
