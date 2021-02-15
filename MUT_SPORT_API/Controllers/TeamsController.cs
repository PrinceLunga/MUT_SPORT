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
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _TeamService;

        public TeamsController(ITeamService _TeamService)
        {
            this._TeamService = _TeamService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TeamModel>> GetTeams()
        {
            return _TeamService.GetTeams();
        }
        [HttpPost]
        public async Task<ActionResult<TeamModel>> PostNewTeam([FromBody] TeamModel model)
        {
            _TeamService.AddNewTeam(model);
            return CreatedAtAction("GetTeams", new { id = model.Id }, model);
        }

        [HttpGet("{id}")]
        public ActionResult<TeamModel> GetTeamByName(int id)
        {
            var _Team = _TeamService.GetTeamById(id);

            if (_Team == null)
            {
                return NotFound();
            }

            return _Team;
        }

        [HttpPut("{id}")]
        public ActionResult<TeamModel> PutEvent(int id, TeamModel model)
        {
            try
            {
                if ((model == null) || (model.Id == 0))
                {
                    return NotFound();
                }
                _TeamService.UpdateTeam(model);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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

        private bool TeamExists(int id)
        {
            return _TeamService.TeamExists(id);
        }
    }
}
