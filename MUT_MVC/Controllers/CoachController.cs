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
    public class CoachController : Controller
    { 
        public async Task<IActionResult> GetCoachById(int id)
        {
            var coaches = new List<CoachModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Coache/GetCoachById/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    coaches = JsonConvert.DeserializeObject<List<CoachModel>>(apiResponse);
                }
            }
            return View(coaches);
        }

        public async Task<IActionResult> GetAllCoaches()
        {
           var coaches = new List<CoachModel>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Coach/GetCoaches"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    coaches = JsonConvert.DeserializeObject<List<CoachModel>>(apiResponse);
                }
            }
            return View(coaches);
        }

        public async Task<ViewResult> CreateCoach()
        {
            var Sports = new List<SportModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Sport/GetSports"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Sports = JsonConvert.DeserializeObject<List<SportModel>>(apiResponse);
                    ViewBag.Sports = Sports;
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoach(CoachModel model)
        {
            var _Coach = new CoachModel();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44330/api/Coach/InsertNewCoach", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _Coach = JsonConvert.DeserializeObject<CoachModel>(apiResponse);
                }
            }
            return RedirectToAction(nameof(GetAllCoaches));
        }
    }
}
