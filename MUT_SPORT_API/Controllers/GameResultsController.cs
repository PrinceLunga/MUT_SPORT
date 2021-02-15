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
    public class GameResultsController : Controller
    {
        private readonly IGameResultService gameResult;

        public GameResultsController(IGameResultService gameResult)
        {
            this.gameResult = gameResult;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<GameResultModel>> GetResults(int id)
        {
            return gameResult.GetGameResultPerSport(id);
        }
    }
}
