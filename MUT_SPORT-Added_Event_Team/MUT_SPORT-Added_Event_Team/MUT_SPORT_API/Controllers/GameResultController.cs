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
    public class GameResultController : ControllerBase
    {
        public readonly IGameResultService gameResuleService;
        public GameResultController(IGameResultService _gameResultService)
        {
            this.gameResuleService = _gameResultService;
        }

        // Api methode to Add game result 

        [HttpGet]
        public ActionResult<IEnumerable<GameResultModel>> GetGameResult()
        {
            return gameResuleService.GetGameResults();
        }



        [HttpPost]
        public async Task<ActionResult<GameResultModel>> PostGameResult([FromBody] GameResultModel model)
        {
            gameResuleService.AddGameResult(model);
            return CreatedAtAction("GetGameResult", new { id = model.Id }, model);
        }


        // Api methode get result buy id

        [HttpGet("{id}")]
        public ActionResult<GameResultModel> GetGameResultID(int id)
        {
            var gameResult = gameResuleService.GetGameResultID( id);

            if (gameResult == null)
            {
                return NotFound();
            }

            return gameResult;
        }

        [HttpPut("{id}")]
        [AcceptVerbs("POST", "PUT")]
        public ActionResult<GameResultModel> Put(int id, GameResultModel model)
        {
            try
            {
                if ((model == null) || (model.Id == 0))
                {
                    return NotFound();
                }
                gameResuleService.UpdateGameResults(model);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameResultExist(id))
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


        private bool GameResultExist(int id)
        {
            return gameResuleService.GameResultExist(id);
        }
       
    }
}

