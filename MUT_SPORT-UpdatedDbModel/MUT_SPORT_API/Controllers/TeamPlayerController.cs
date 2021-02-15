using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class TeamPlayerController : ControllerBase
    {
        private readonly ITeamPlayerService teamPlayerService;

        public TeamPlayerController(ITeamPlayerService _teamPlayerService)
        {
            this.teamPlayerService = _teamPlayerService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TeamPlayerModel>> GetTeamPlayers()
        {
            return teamPlayerService.GetTeamPlayers();
        }

        [HttpPost]
        public async Task<ActionResult<TeamPlayerModel>> PostTeamPlayer(TeamPlayerModel model)
        {
            teamPlayerService.AddNewTeamPlayer(model);
            return CreatedAtAction("GetTeamPlayers", new { id = model.Id }, model);
        }

        [HttpGet("{id}")]
        public ActionResult<TeamPlayerModel> GetTeamPlayerById(int id)
        {
            var TeamPlayer = teamPlayerService.GetTeamPlayerById(id);

            if (TeamPlayer == null)
            {
                return NotFound();
            }

            return TeamPlayer;
        }

        [HttpPut("{id}")]
        [AcceptVerbs("POST", "PUT")]
        public ActionResult<TeamPlayerModel> UpdateTeamPlayer(int id, TeamPlayerModel model)
        {
            try
            {
                if ((model == null) || (model.Id == 0))
                {
                    return NotFound();
                }
                teamPlayerService.UpdateTeamPlayer(model);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamPlayerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return model;
        }
        private bool TeamPlayerExists(int id)
        {
            return teamPlayerService.TeamPlayerExists(id);
        }

    }
}
