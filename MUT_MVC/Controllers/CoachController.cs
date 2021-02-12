using Microsoft.AspNetCore.Mvc;
using MUT_MODELS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MUT_MVC.Controllers
{
    public class CoachController : Controller
    {
        private List<SportModel> sportList;

        public CoachController()
        {
            sportList = new List<SportModel>();
        }
        public IActionResult CoachDashBoard()
        {
            return View();
        }


        public async Task<IActionResult> GetMyStudentsSports()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Sport/GetSports"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    sportList = JsonConvert.DeserializeObject<List<SportModel>>(apiResponse);
                }
            }
            return View(sportList);
        }

    }
}
