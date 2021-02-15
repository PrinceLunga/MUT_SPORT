using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class EventController : ControllerBase
    {
        private readonly IEventService _EventService;

        public EventController(IEventService _EventService)
        {
            this._EventService = _EventService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<EventModel>> GetAllEvents()
        {
            return _EventService.GetAllEvents();
        }

        [HttpPost]
        public async Task<ActionResult<EventModel>> PostNewEvent([FromBody] EventModel model)
       {
            _EventService.InsertNewEvent(model);
            return CreatedAtAction("GetAllEvents", new { id = model.Id }, model);
        }

        [HttpGet("{name}")]
        public ActionResult<EventModel> GetEventByName(string name)
        {
            var ExistEvent = _EventService.GetEventByName(name);

            if (ExistEvent == null)
            {
                return NotFound();
            }

            return ExistEvent;
        }

        [HttpPut("{id}")]
        [AcceptVerbs("POST", "PUT")]
        public ActionResult<EventModel> PutEvent(int id, EventModel model)
        {
            try
            {
                if ((model == null) || (model.Id == 0))
                {
                    return NotFound();
                }
                _EventService.UpdateEvent(model);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return model;
        }

        private bool EventExists(int id)
        {
            return _EventService.EventExists(id);
        }
    }
}
