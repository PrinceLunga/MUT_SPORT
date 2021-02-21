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
    public class TeamPlayerController : ControllerBase
    {
        private readonly ITeamPlayerService _TeamPlayerService;
        public TeamPlayerController(ITeamPlayerService _TeamPlayerService)
        {
            this._TeamPlayerService = _TeamPlayerService;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<TeamPlayerModel>> GetTeamPlayerByID(int id)
        {
            return _TeamPlayerService.GetTeamPlayerByID(id);
        }

        [HttpGet]
        public ActionResult<IEnumerable<TeamPlayerModel>> GetAllTeamPlayers()
        {
            return _TeamPlayerService.GetAllTeamPlayers();
        }

        [HttpPost]
        public async Task<ActionResult<TeamPlayerModel>> AddTeamPlayer(TeamPlayerModel model)
        {
            _TeamPlayerService.AddTeamPlayer(model);
            return CreatedAtAction("GetPlayerAchievements", new { FirstName = model.Student.FirstName }, model);
        }

    }
}
