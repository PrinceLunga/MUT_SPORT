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
    public class GameResultController : Controller
    {
        private List<GameResultModel> GameResultList;
        public GameResultController()
        {
            this.GameResultList = new List<GameResultModel>();

        }
        [HttpGet]
        public async Task<IActionResult> GetGameResult()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/GameResult/GetGameResult"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    GameResultList = JsonConvert.DeserializeObject<List<GameResultModel>>(apiResponse);
                }
            }
            return View(GameResultList);
        }

        public ViewResult PostGameResult() => View();

        [HttpPost]
        public async Task<IActionResult> PostGameResult(GameResultModel gameResult)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(gameResult), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44330/api/GameResult/PostGameResult", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction(nameof(GetGameResult));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGameResults(GameResultModel gameResultModel)
        {
            using (var httpClient = new HttpClient())
            {
                string recievedEvent = JsonConvert.SerializeObject(gameResultModel);

                var inputMessage = new HttpRequestMessage
                {
                    Content = new StringContent(recievedEvent, Encoding.UTF8, "application/json")
                };

                inputMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage message = httpClient.PutAsync("https://localhost:44330/GameResul//PutGameResult" +
                    "", inputMessage.Content).Result;

                if (!message.IsSuccessStatusCode)
                    throw new ArgumentException(message.ToString());

                return RedirectToAction("GetAllEvents");
            }
        }
    }
}
