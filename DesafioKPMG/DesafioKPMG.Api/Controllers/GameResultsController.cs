using DesafioKPMG.DataService.IDataConfiguration;
using DesafioKPMG.Entities.Dtos.Incoming;
using DesafioKPMG.Entities.Dtos.Outgoing;
using DesafioKPMG.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace DesafioKPMG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameResultsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitOfWorkCache _cache;
        public GameResultsController(
            IUnitOfWork unitOfWork,
            IUnitOfWorkCache cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }
        [HttpPost]
        public async Task<IActionResult> AddGameResult(GameResultInDto gameResultDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var player = await _unitOfWork.Players
                .GetById(gameResultDto.PlayerId);
            if (player == null)
                return BadRequest(new { message = $"Player Id {gameResultDto.PlayerId} not found." });

            var gameResult = new GameResult();
            gameResult.PlayerId = gameResultDto.PlayerId;
            gameResult.Win = gameResultDto.Win;
            gameResult.Timestamp = gameResultDto.Timestamp;

            long cacheCount = _cache.GameResultsCache.GetCacheCount();
            _cache.GameResultsCache.SetCacheCount(++cacheCount);
            _cache.GameResultsCache.Add(cacheCount, gameResult);

            return Ok(gameResultDto);
        }
        [HttpGet]
        [Route("GetResult", Name = "GetResult")]
        public async Task<IActionResult> GetResult(long Id)
        {
            var gameResult = await _unitOfWork.GameResults.GetById(Id);

            if (gameResult == null)
                return NotFound();

            var gameResultDto = new GameResultOutDto();
            gameResultDto.PlayerId = gameResult.PlayerId;
            gameResultDto.GameId = gameResult.GameId;
            gameResultDto.Win = gameResult.Win;
            gameResultDto.Timestamp = gameResult.Timestamp;

            return Ok(gameResultDto);
        }
    }
}
