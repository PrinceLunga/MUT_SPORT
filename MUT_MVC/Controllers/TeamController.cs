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
    public class TeamController : Controller
    {
        private List<TeamModel> TeamsList;
        private TeamModel TeamModel;

        public TeamController()
        {
            TeamsList = new List<TeamModel>();
            TeamModel = new TeamModel();
        }
        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Teams/GetTeams"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    TeamsList = JsonConvert.DeserializeObject<List<TeamModel>>(apiResponse);
                }
            }
            return View(TeamsList);
        }

        public ViewResult PostTeam() => View(); 

        [HttpPost]
        public async Task<IActionResult> PostTeam([FromForm] TeamModel _TeamModel)
        {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(_TeamModel), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("https://localhost:44330/api/Teams/PostNewTeam", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
            return RedirectToAction(nameof(GetTeams));
        }

        public async Task<IActionResult> UpdateTeam(string name)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/api/Teams/GetTeamByName" + name))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    TeamModel = JsonConvert.DeserializeObject<TeamModel>(apiResponse);
                }
            }
            return View(TeamModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEvent(EventModel eventModel)
        {
            using (var httpClient = new HttpClient())
            {
                string recievedEvent= JsonConvert.SerializeObject(eventModel);

                var inputMessage = new HttpRequestMessage
                {
                    Content = new StringContent(recievedEvent, Encoding.UTF8, "application/json")
                };

                inputMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage message = httpClient.PutAsync("https://localhost:44330/api/Teams/PutTeam", inputMessage.Content).Result;

                if (!message.IsSuccessStatusCode)
                    throw new ArgumentException(message.ToString());

                return RedirectToAction("GetAllEvents");
            }
        }
    }
}
