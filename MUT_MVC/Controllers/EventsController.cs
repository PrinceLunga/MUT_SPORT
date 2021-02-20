using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MUT_MVC.Models;
using MUT_Service.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MUT_MVC.Controllers
{
    public class EventsController : Controller
    {

        private List<UpComingEventsMvcModel> events;
        public EventsController()
        {
            events = new List<UpComingEventsMvcModel>();
        }

        public async Task<IActionResult> UpcomingEvents(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Events/GetEvents/"+ id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    events = JsonConvert.DeserializeObject<List<UpComingEventsMvcModel>>(apiResponse);
                }
            }
            return View(events);
        }

        public ViewResult AddEvent() => View();
        [HttpPost]
        public async Task<IActionResult> AddEvent([FromForm] UpComingEventsMvcModel model)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44330/Api/Events/PostEvent", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    events = JsonConvert.DeserializeObject<List<UpComingEventsMvcModel>>(apiResponse);
                }
            }
            return View(events);
        }


    }
}
