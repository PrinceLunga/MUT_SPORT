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
        private List<AchievementModel> achievements;

        public AchievementsController()
        {
            achievements = new List<AchievementModel>();
        }
        public async Task<IActionResult> GetAchievementById(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Achievements/GetAchievementByID/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    achievements = JsonConvert.DeserializeObject<List<AchievementModel>>(apiResponse);
                }
            }
            return View(achievements);
        }

        public async Task<IActionResult> GetAchievements()
        {
            var _achievement = new List<AchievementModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Achievements/GetAllAchievements"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _achievement = JsonConvert.DeserializeObject<List<AchievementModel>>(apiResponse);
                }
            }
            return View(_achievement);
        }

        public ViewResult CreateAchievement() => View();

        [HttpPost]
        public async Task<IActionResult> CreateAchievement(AchievementModel model)
        {
            AchievementModel _Achievement = new AchievementModel();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44330/Api/Achievements/AddAchievement", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _Achievement = JsonConvert.DeserializeObject<AchievementModel>(apiResponse);
                }
            }
            return RedirectToAction(nameof(GetAchievements));
        }
    }
}
