using DesafioKPMG.DataService.IDataConfiguration;
using DesafioKPMG.Entities.Dtos.Outgoing;
using DesafioKPMG.Entities.Incoming.Dtos;
using DesafioKPMG.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioKPMG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PlayersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<IActionResult> AddPlayer(PlayerInDto playerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool ExistUsername = _unitOfWork.Players
                .ExistUsername(playerDto.Username);
            if (ExistUsername == true)
                return Conflict(new { message = $"Username {playerDto.Username} already taken"});

            var player = new Player
            {
                Username = playerDto.Username,
            };
            await _unitOfWork.Players.Add(player);
            await _unitOfWork.CompleteAsync();

            return CreatedAtRoute(
                routeName: "GetPlayer",
                routeValues: new { Id = player.Id },
                value: playerDto);
        }
        [HttpGet]
        [Route("GetPlayer", Name = "GetPlayer")]
        public async Task<IActionResult> GetPlayer(long Id)
        {
            var player = await _unitOfWork.Players.GetById(Id);
                
            if (player == null)
                return NotFound();

            var playerDto = new PlayerOutDto();
            playerDto.Id = player.Id;
            playerDto.Username = player.Username;
            playerDto.GameResults = player.GameResults;
            playerDto.Balance = player.Balance;
            playerDto.LastUpdateDate = player.LastUpdateDate;

            return Ok(playerDto);
        }
        [HttpGet]
        [Route("LeaderBoard")]
        public IActionResult LeaderBoard()
        {
            var leadersDto = _unitOfWork.Players
                .LeaderBoard()
                .Select(p => new LeaderBoardDto
                {
                    PlayerId = p.Id,
                    Balance = p.Balance,
                    LastUpdateDate = p.LastUpdateDate.ToLocalTime(),
                });
            return Ok(leadersDto);
        }

    }
}
