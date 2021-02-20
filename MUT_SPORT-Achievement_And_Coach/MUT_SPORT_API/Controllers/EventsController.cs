using Microsoft.AspNetCore.Mvc;
using MUT_MODELS;
using MUT_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MUT_SPORT_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventsController : Controller
    {
        private readonly IEventService eventService;

        public EventsController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventModel>> GetAllEvents()
        {
            return eventService.GetAllEvents();
        }

        [HttpPost]
        public async Task<ActionResult<EventModel>> AddNewEvent([FromForm] EventModel model)
        {
            eventService.InsertNewEvent(model);
            return CreatedAtAction("GetllEvents", new { id = model.Id }, model);
        }
    }
}
