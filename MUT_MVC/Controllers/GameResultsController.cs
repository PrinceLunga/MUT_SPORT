using Microsoft.AspNetCore.Mvc;
using MUT_MVC.Models;
using MUT_Service.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MUT_MVC.Controllers
{
    public class GameResultsController : Controller
    {
        private List<GameResultMvcModel> results;
        public GameResultsController()
        {
            results = new List<GameResultMvcModel>();
        }

        public async Task<IActionResult> PreviousResults(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/GameResults/GetResults/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    results = JsonConvert.DeserializeObject<List<GameResultMvcModel>>(apiResponse);
                }
            }
            return View(results);
        }
    }
}
