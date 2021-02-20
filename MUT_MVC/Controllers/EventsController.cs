using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MUT_MODELS;
using MUT_MVC.Models;
using MUT_Service.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MUT_MVC.Controllers
{
    public class EventsController : Controller
    {
        private List<SportModel> Sports;
        public EventsController()
        {
            Sports = new List<SportModel>();
        }

        public async Task<IActionResult> GetAllUpcomingEvents()
        {
            var events = new List<UpComingEventsModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Events/GetAllEvents"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    events = JsonConvert.DeserializeObject<List<UpComingEventsModel>>(apiResponse);
                }
            }
            return View(events);
        }


        public async Task<IActionResult> UpcomingEvents(int id)
        {
            var events = new List<UpComingEventsModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Events/GetEvents/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    events = JsonConvert.DeserializeObject<List<UpComingEventsModel>>(apiResponse);
                }
            }
            return View(events);
        }

        public async Task<ViewResult> AddEvent()
        {
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
        public async Task<IActionResult> AddEvent([FromForm] AddUpComingEventModel model)
        {

            string _EventPicture = "";
            var response = new HttpResponseMessage();


            using (var memoryStream = new MemoryStream())
            {
                await model.EventPicture.CopyToAsync(memoryStream);
                var a = memoryStream.ToArray();
                _EventPicture = Convert.ToBase64String(a);
            }

            var _UpComingEvent = new UpComingEventsMvcModel
            {
                DateDeleted = DateTime.Now,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Descriptions = model.Descriptions,
                SportName = model.SportName,
                EventPicture = _EventPicture,
                EndingDate = model.EndingDate,
                SportId = 1,
                StartingDate = model.StartingDate,
                Venue = model.Venue,
                Id = model.Id
            };

            var formDataContent = new MultipartFormDataContent();
            formDataContent.Add(new StringContent(_UpComingEvent.DateCreated.ToString()), "datecreated");
            formDataContent.Add(new StringContent(_UpComingEvent.DateDeleted.ToString()), "dateclosed");
            formDataContent.Add(new StringContent(_UpComingEvent.DateModified.ToString()), "datemodified");
            formDataContent.Add(new StringContent(_UpComingEvent.Descriptions), "descriptions");
            formDataContent.Add(new StringContent(_UpComingEvent.SportName), "sportname");
            formDataContent.Add(new StringContent(_UpComingEvent.EventPicture), "EventPicture");
            formDataContent.Add(new StringContent(_UpComingEvent.EndingDate), "endingdate");
            formDataContent.Add(new StringContent(_UpComingEvent.SportId.ToString()), "sportid");
            formDataContent.Add(new StringContent(_UpComingEvent.StartingDate), "startingdate");
            formDataContent.Add(new StringContent(_UpComingEvent.Venue), "venue");
            formDataContent.Add(new StringContent(_UpComingEvent.Id.ToString()), "id");

            using (var httpClient = new HttpClient())
            {
                response = await httpClient.PostAsync("https://localhost:44330/Api/Events/PostEvent", formDataContent);
                var data = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
            }
            return RedirectToAction(nameof(GetAllUpcomingEvents));
        }


    }
}
