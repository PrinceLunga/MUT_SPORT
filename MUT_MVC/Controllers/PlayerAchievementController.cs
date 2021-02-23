using Microsoft.AspNetCore.Mvc;
using MUT_MODELS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MUT_MVC.Controllers
{
    public class PlayerAchievementController : Controller
    {
        private List<PlayerAchievementModel> _PlayerAchievementModel;

        public PlayerAchievementController()
        {
            _PlayerAchievementModel = new List<PlayerAchievementModel>();
        }
        public async Task<IActionResult> GetAchievementById(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/PlayerAchievement/GetAchievementByID/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _PlayerAchievementModel = JsonConvert.DeserializeObject<List<PlayerAchievementModel>>(apiResponse);
                }
            }
            return View(_PlayerAchievementModel);
        }

        public async Task<IActionResult> GetAllPlayerAchievements()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/PlayerAchievement/GetPlayerAchievements"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _PlayerAchievementModel = JsonConvert.DeserializeObject<List<PlayerAchievementModel>>(apiResponse);
                }
            }
            return View(_PlayerAchievementModel);
        }

        public async Task<ViewResult> CreatePlayerAchievement()
        {
            var _Achievements = new List<AchievementModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Achievements/GetAllAchievements"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _Achievements = JsonConvert.DeserializeObject<List<AchievementModel>>(apiResponse);
                    ViewBag.Achievements = _Achievements;
                }
            }

            var _Students = new List<StudentModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Student/GetStudents"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Students = JsonConvert.DeserializeObject<List<StudentModel>>(apiResponse);
                }


            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayerAchievement(PlayerAchievementModel model)
        {
            PlayerAchievementModel _Achievement = new PlayerAchievementModel();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44330/Api/PlayerAchievement/AddPlayerAchievement", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _Achievement = JsonConvert.DeserializeObject<PlayerAchievementModel>(apiResponse);
                }
            }
            return RedirectToAction(nameof(GetAllPlayerAchievements));
        }
    }
}
