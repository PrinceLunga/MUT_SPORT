using Microsoft.AspNetCore.Mvc;
using MUT_DataAccess.DataModels;
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

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<UpComingEventsModel>> GetEvents(int id)
        {
            return eventService.GetEventsBySportId(id);
        }

        [HttpGet("{id}")]
        public ActionResult<UpComingEventsModel> GetEventById(int id)
        {
            return eventService.GetEventById(id);
        }

        [HttpPost]
        public async Task<ActionResult<UpComingEventsModel>> PostEvent([FromBody] UpComingEventsModel model)
        {
            eventService.InsertNewEvent(model);
            return CreatedAtAction("GetEvents", new { id = model.Id }, model);
        }

        [HttpPost]
        public async Task<ActionResult<UpComingEvent>> PutEvent([FromBody] UpComingEventsModel model)
        {
            if(ModelState.IsValid)
                return eventService.UpdateEvent(model);

            return new UpComingEvent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UpComingEventsModel>> DropEvent(int id)
        {
            eventService.DeleteEvent(id);
            return Ok();
        }
    }
}
