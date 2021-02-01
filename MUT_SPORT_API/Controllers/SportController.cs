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
    public class SportController : ControllerBase
    {
        private readonly ISportService _sportService;

        public SportController(ISportService sportService)
        {
            this._sportService = sportService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SportModel>> GetSports()
        {
            return _sportService.GetAllSports();
        }

        [HttpPost]
        public async Task<ActionResult<SportModel>> PostSport([FromForm] SportModel model)
        {
             _sportService.InsertNewSport(model);
            return CreatedAtAction("GetSports", new { id = model.Id }, model);
        }

        [HttpGet("{id}")]
        public ActionResult<SportModel> GetSportById(int id)
        {
            var sport = _sportService.GetSportById(id);

            if (sport == null)
            {
                return NotFound();
            }

            return sport;
        }

        [HttpPut("{id}")]
        [AcceptVerbs("POST", "PUT")]
        public ActionResult<SportModel> PutSports(int id, SportModel model)
        {
            try
            {
                if ((model == null) || (model.Id == 0))
                {
                    return NotFound();
                }
                _sportService.UpdateSport(model);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportExists(id))
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

        private bool SportExists(int id)
        {
            return _sportService.SportExists(id);
        }

    }
}
