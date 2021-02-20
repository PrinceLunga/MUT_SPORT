using Microsoft.AspNetCore.Mvc;
using MUT_MODELS;
using MUT_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MUT_SPORT_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ResidenceController : ControllerBase
    {
        public readonly IResidenceService residenceService;

        public ResidenceController(IResidenceService residenceService)
        {
            this.residenceService = residenceService;
        }

        [HttpGet]
        public List<ResModel> GetAllResidences()
        {
            if (ModelState.IsValid)
            {
                return residenceService.GetResidences();
            }
            return new List<ResModel>();
        }

    }
}
