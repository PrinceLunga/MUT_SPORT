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
    public class CoachController : ControllerBase
    {
        private readonly ICoachService coachService;

        public CoachController(ICoachService _coachService)
        {
            this.coachService = _coachService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CoachModel>> GetCoaches()
        {
            return coachService.GetAllCoaches();
        }

        [HttpPost]
        public async Task<ActionResult<CoachModel>> PostCoach([FromForm] CoachModel model)
        {
            coachService.InsertNewCoach(model);
            return CreatedAtAction("GetCoaches", new { id = model.Id }, model);
        }

        [HttpGet("{id}")]
        public ActionResult<CoachModel> GetCoachById(int id)
        {
            var sport = coachService.GetCoachById(id);

            if (sport == null)
            {
                return NotFound();
            }

            return sport;
        }

        [HttpPut("{id}")]
        [AcceptVerbs("POST", "PUT")]
        public ActionResult<CoachModel> PutSports(int id, CoachModel model)
        {
            try
            {
                if ((model == null) || (model.Id == 0))
                {
                    return NotFound();
                }
                coachService.UpdateCoach(model);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoachExists(id))
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

        private bool CoachExists(int id)
        {
            return coachService.CoachExists(id);
        }
    }
}
