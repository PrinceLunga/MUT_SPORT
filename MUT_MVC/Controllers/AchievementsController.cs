using Microsoft.AspNetCore.Mvc;
using MUT_MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MUT_MVC.Controllers
{
    public class AchievementsController : Controller
    {
        private List<AchievementMvcModel> achievements;

        public AchievementsController()
        {
            achievements = new List<AchievementMvcModel>();
        }
        public async Task<IActionResult> TeamAchievements(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Achievements/GetTeamAchievements/"+id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    achievements = JsonConvert.DeserializeObject<List<AchievementMvcModel>>(apiResponse);
                }
            }
            return View(achievements);
        }

        public async Task<IActionResult> PlayerAchievements(string playerID)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Achievements/GetPlayerAchievements/" + playerID))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    achievements = JsonConvert.DeserializeObject<List<AchievementMvcModel>>(apiResponse);
                }
            }
            return View(achievements);
        }
    }
}
