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
        private List<CoachModel> coaches;
        private List<SportModel> Sports;
        public CoachController()
        {
            coaches = new List<CoachModel>();
            Sports = new List<SportModel>();
        }
        public async Task<IActionResult> GetCoachById(int id)
        {
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

        public async Task<IActionResult> GetCoaches()
        {
            List<CoachModel> coaches = new List<CoachModel>();

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
            List<SportModel> Sports = new List<SportModel>();
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
            using (var httpClient = new HttpClient())
            {
                List<SportModel> Sports = new List<SportModel>();
                ViewBag.listofSport = Sports;
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44330/api/Coach/GetCoaches", content))
                {
                    ViewBag.listofSport = Sports;
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("GetCoaches");
                    }
                }

            }
            return View(model);
        }
    }
}
