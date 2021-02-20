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
        private CoachEventsMvcModel upcomingEvent;
        public EventsController()
        {
            events = new List<UpComingEventsMvcModel>();
            upcomingEvent = new CoachEventsMvcModel();
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

        public async Task<IActionResult> CoachEvents(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Events/GetEvents/" + 2))
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
                    if(response.IsSuccessStatusCode)
                        return RedirectToAction(nameof(CoachEvents));
                }
            }
            return NotFound();
        }

        
        public async Task<IActionResult> UpdateEvent(int id)
        {

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Events/GetEventById/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    upcomingEvent = JsonConvert.DeserializeObject<CoachEventsMvcModel>(apiResponse);
                }
            }
            return View(upcomingEvent);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEvent(CoachEventsMvcModel model)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44330/Api/Events/PutEvent", content))
                {
                    if (response.IsSuccessStatusCode)
                        return RedirectToAction(nameof(CoachEvents));
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> RemoveEvent(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44330/Api/Events/DropEvent/"+id))
                {
                    if (response.IsSuccessStatusCode)
                        return RedirectToAction(nameof(CoachEvents));
                }
            }
            return NotFound();
        }

    }
}
