using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MUT_DataAccess.DataModels;
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
    public class AchievementsController : ControllerBase
    {
        private readonly IAchievementService achievementService;
        public AchievementsController(IAchievementService achievementService)
        {
            this.achievementService = achievementService;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<AchievementModel>> GetAchievementByID(int id)
        {
            return achievementService.GetAchievementByID(id);
        }

        [HttpGet]
        public ActionResult<IEnumerable<AchievementModel>> GetAllAchievements()
        {
            return achievementService.GetAchievements();
        }

        [HttpPost]
        public async Task<ActionResult<AchievementModel>> AddAchievement(AchievementModel model)
        {
            achievementService.AddAchievement(model);
            return CreatedAtAction("GetPlayerAchievements", new { AchievementDescription = model.AchievementDescription }, model);
        }

    }
}
