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
    public class TeamPlayerController : Controller
    {
        private List<TeamPlayerModel> _TeamPlayers;

        public TeamPlayerController()
        {
            _TeamPlayers = new List<TeamPlayerModel>();
        }
        public async Task<IActionResult> GetTeamPlayerByID(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/TeamPlayer/GetTeamPlayerByID/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _TeamPlayers = JsonConvert.DeserializeObject<List<TeamPlayerModel>>(apiResponse);
                }
            }
            return View(_TeamPlayers);
        }

        public async Task<IActionResult> GetTeamPlayers()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/TeamPlayer/GetAllTeamPlayers"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _TeamPlayers = JsonConvert.DeserializeObject<List<TeamPlayerModel>>(apiResponse);
                }
            }
            return View(_TeamPlayers);
        }

        public ViewResult CreateAchievement() => View();

        [HttpPost]
        public async Task<IActionResult> CreateAchievement(TeamPlayerModel model)
        {
            TeamPlayerModel _TeamPlayer = new TeamPlayerModel();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44330/Api/TeamPlayer/AddTeamPlayer", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _TeamPlayer = JsonConvert.DeserializeObject<TeamPlayerModel>(apiResponse);
                }
            }
            return RedirectToAction(nameof(GetTeamPlayers));
        }
    }
}
