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
    public class SportController : ControllerBase
    {
        private readonly ISportService _sportService;

        public SportController(ISportService sportService)
        {
            this._sportService = sportService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SportModel>> Index()
        {
            return _sportService.GetAllSports();
        }
    }
}
