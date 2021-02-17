using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MUT_DataAccess.DataModels;
using MUT_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MUT_SPORT_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AchievementsController : ControllerBase
    {
        private readonly ITeamAchievement teamAchievement;
        private readonly IPlayerAchievement playerAchievement;
        public AchievementsController(ITeamAchievement teamAchievement, IPlayerAchievement playerAchievement)
        {
            this.teamAchievement = teamAchievement;
            this.playerAchievement = playerAchievement;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Achievement>> GetTeamAchievements(int id)
        {
            return teamAchievement.GetTeamAchievements(id);
        }

        [HttpGet("{playerID}")]
        public ActionResult<IEnumerable<Achievement>> GetPlayerAchievements(int playerID)
        {
            return playerAchievement.GetPlayerAchievements(playerID);
        }
    }
}
