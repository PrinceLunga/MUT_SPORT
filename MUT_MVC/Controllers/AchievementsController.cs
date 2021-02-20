using Microsoft.AspNetCore.Mvc;
using MUT_MODELS;
using MUT_MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        public async Task<IActionResult> GetAchievementById(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Achievements/GetAchievementByID/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    achievements = JsonConvert.DeserializeObject<List<AchievementMvcModel>>(apiResponse);
                }
            }
            return View(achievements);
        }

        public async Task<IActionResult> GetAchievements()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Achievements/GetPlayerAchievements"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    achievements = JsonConvert.DeserializeObject<List<AchievementMvcModel>>(apiResponse);
                }
            }
            return View(achievements);
        }

        public async Task<IActionResult> TeamAchievements(int id)
        {
            var teamAchievements = new List<AchievementMvcModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Team/GetAchievements/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    teamAchievements = JsonConvert.DeserializeObject<List<AchievementMvcModel>>(apiResponse);
                }
            }
            return View(teamAchievements);
        }

        public async Task<IActionResult> PlayerAchievements()
        {
            var playerAchievements = new List<AchievementMvcModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Achievements/GetPlayerAchievements"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    playerAchievements = JsonConvert.DeserializeObject<List<AchievementMvcModel>>(apiResponse);
                }
            }
            return View(playerAchievements);
        }

        public ViewResult CreateAchievement() => View();

        [HttpPost]
        public async Task<IActionResult> CreateAchievement(AchievementMvcModel model)
        {
            AchievementMvcModel _Achievement = new AchievementMvcModel();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44330/Api/Achievements/AddAchievement", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _Achievement = JsonConvert.DeserializeObject<AchievementMvcModel>(apiResponse);
                }
            }
            return RedirectToAction(nameof(GetAchievements));
        }
    }
}
