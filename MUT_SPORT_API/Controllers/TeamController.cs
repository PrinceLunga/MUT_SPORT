using Microsoft.AspNetCore.Http;
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
    public class TeamController : ControllerBase
    {
        private readonly ITeamAchievement teamAchievement;
        private readonly ITeamService teamService;

        public TeamController(ITeamAchievement teamAchievement, ITeamService teamService)
        {
            this.teamAchievement = teamAchievement;
            this.teamService = teamService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TeamModel>> GetTeams()
        {
            return teamService.GetAllTeams();
        }

        [HttpGet("{teamId}")]
        public ActionResult<IEnumerable<AchievementModel>> GetAchievements(int teamId)
        {
            return teamAchievement.GetTeamAchievements(teamId);
        }
    }
}
