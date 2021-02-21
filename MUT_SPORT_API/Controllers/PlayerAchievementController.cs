using Microsoft.AspNetCore.Mvc;
using MUT_MODELS;
using MUT_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MUT_SPORT_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlayerAchievementController : ControllerBase
    {
        private readonly IPlayerAchievementService playerAchievementService;
        public PlayerAchievementController(IPlayerAchievementService playerAchievementService)
        {
            this.playerAchievementService = playerAchievementService;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<PlayerAchievementModel>> GetAchievementByID(int Id)
        {
            return playerAchievementService.GetPlayerAchievementByID(Id);
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlayerAchievementModel>> GetPlayerAchievements()
        {
            return playerAchievementService.GetPlayersAchievements();
        }

        [HttpPost]
        public async Task<ActionResult<PlayerAchievementModel>> AddPlayerAchievement(PlayerAchievementModel model)
        {
            playerAchievementService.AddPlayerAchievement(model);
            return CreatedAtAction("GetPlayerAchievements", new { PlayerId = model.PlayerId }, model);
        }
    }
}
