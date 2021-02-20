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
        private readonly ITeamService teamService;
        public TeamController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<TeamModel>> GetTeamByID(int id)
        {
            return teamService.GetTeamByID(id);
        }

        [HttpGet]
        public ActionResult<IEnumerable<TeamModel>> GetTeams()
        {
            return teamService.GetTeams();
        }

        [HttpPost]
        public async Task<ActionResult<TeamModel>> AddTeam(TeamModel model)
        {
            teamService.AddTeam(model);
            return CreatedAtAction("GetTeams", new { TeanName = model.TeamName }, model);
        }
    }
}
