using Microsoft.AspNetCore.Mvc;
using MUT_MODELS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MUT_MVC.Controllers
{
    public class TeamPlayerController : Controller
    {
        public async Task<IActionResult> GetTeamPlayers()
        {
            List<TeamPlayerModel> reservationList = new List<TeamPlayerModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/api/TeamPlayer/GetTeamPlayers"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<List<TeamPlayerModel>>(apiResponse);
                }
            }
            return View(reservationList);
        }

        public ViewResult PostTeamPlayer() => View();

        [HttpPost]
        public async Task<IActionResult> PostTeamPlayer(TeamPlayerModel teamPlayerModel)
        {
            TeamPlayerModel _TeamPlayerModel = new TeamPlayerModel();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(teamPlayerModel), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44330/api/TeamPlayer/PostTeamPlayer", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _TeamPlayerModel = JsonConvert.DeserializeObject<TeamPlayerModel>(apiResponse);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateTeamPlayer(int id)
        {
            TeamPlayerModel teamPlayerModel = new TeamPlayerModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/api/TeamPlayer/GetTeamPlayerById/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    teamPlayerModel = JsonConvert.DeserializeObject<TeamPlayerModel>(apiResponse);
                }
            }
            return View(teamPlayerModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTeamPlayer(TeamPlayerModel teamPlayer)
        {
            using (var httpClient = new HttpClient())
            {
                string serailizedProduct = JsonConvert.SerializeObject(teamPlayer);

                var inputMessage = new HttpRequestMessage
                {
                    Content = new StringContent(serailizedProduct, Encoding.UTF8, "application/json")
                };

                inputMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage message = httpClient.PutAsync("https://localhost:44330/api/TeamPlayer/UpdateTeamPlayer", inputMessage.Content).Result;

                if (!message.IsSuccessStatusCode)
                    throw new ArgumentException(message.ToString());

                return RedirectToAction("GetTeamPlayers");
            }
        }

    }
}
