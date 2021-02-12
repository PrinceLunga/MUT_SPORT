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
    public class EventController : Controller
    {
        private List<EventModel> EventsList;
        private EventModel EventModel;

        public EventController()
        {
            this.EventsList = new List<EventModel>();
            this.EventModel = new EventModel();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Event/GetAllEvents"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    EventsList = JsonConvert.DeserializeObject<List<EventModel>>(apiResponse);
                }
            }
            return View(EventsList);
        }

        public ViewResult PostEvent() => View();

        [HttpPost]
        public async Task<IActionResult> PostEvent(EventModel student)
        {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("https://localhost:44330/api/Event/PostNewEvent", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
            return RedirectToAction(nameof(GetAllEvents));
        }

        public async Task<IActionResult> UpdateEvent(string name)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/api/Event/GetEventByName" + name))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    EventModel = JsonConvert.DeserializeObject<EventModel>(apiResponse);
                }
            }
            return View(EventModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGroup(EventModel eventModel)
        {
            using (var httpClient = new HttpClient())
            {
                string recievedEvent= JsonConvert.SerializeObject(eventModel);

                var inputMessage = new HttpRequestMessage
                {
                    Content = new StringContent(recievedEvent, Encoding.UTF8, "application/json")
                };

                inputMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage message = httpClient.PutAsync("https://localhost:44330/api/Event/PutEvent", inputMessage.Content).Result;

                if (!message.IsSuccessStatusCode)
                    throw new ArgumentException(message.ToString());

                return RedirectToAction("GetEvents");
            }
        }
    }
}
