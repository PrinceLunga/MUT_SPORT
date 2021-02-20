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
    public class TeamController : Controller
    {
        private List<TeamModel> teamList;

        public TeamController()
        {
            teamList = new List<TeamModel>();
        }
        public async Task<IActionResult> GetTeamById(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Team/GetTeamByID/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    teamList = JsonConvert.DeserializeObject<List<TeamModel>>(apiResponse);
                }
            }
            return View(teamList);
        }

        public async Task<IActionResult> GetAllTeams()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Team/GetTeams"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    teamList = JsonConvert.DeserializeObject<List<TeamModel>>(apiResponse);
                }
            }
            return View(teamList);
        }

        public async Task<ViewResult> AddNewTeam()
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
        public async Task<IActionResult> AddNewTeam(TeamModel model)
        {
            TeamModel _Team = new TeamModel();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44330/Api/Team/AddTeam", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _Team = JsonConvert.DeserializeObject<TeamModel>(apiResponse);
                }
            }
            return RedirectToAction(nameof(GetAllTeams));
        }

    }
}
