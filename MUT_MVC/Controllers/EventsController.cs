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
using System.Threading.Tasks;

namespace MUT_MVC.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService eventService;
        private List<UpComingEventsMvcModel> events;
        public EventsController(IEventService eventService)
        {
            this.eventService = eventService;
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

        public async Task<IActionResult> AddEvent(UpComingEventsMvcModel model)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Events/PostEvent"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    events = JsonConvert.DeserializeObject<List<UpComingEventsMvcModel>>(apiResponse);
                }
            }
            return View(events);
        }


    }
}
