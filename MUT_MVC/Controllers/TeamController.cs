using Microsoft.AspNetCore.Mvc;
using MUT_MODELS;
using MUT_MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MUT_MVC.Controllers
{
    public class TeamController : Controller
    {
        public List<TeamMvcModel> teams;

        public TeamController()
        {
            teams = new List<TeamMvcModel>();
        }

        public async Task<IActionResult> Teams()
        {
            using (var httpClient = new HttpClient())

            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Team/GetTeams"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    teams = JsonConvert.DeserializeObject<List<TeamMvcModel>>(apiResponse);
                }
            }
            return View(teams);
        }
        
    }
}
