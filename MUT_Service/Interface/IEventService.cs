using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_Service.Interface
{
    public interface IEventService
    {
        public List<EventModel> GetAllEvents();
        public void InsertNewEvent(EventModel eventModel);
        public void UpdateEvent(EventModel eventModel);
        public EventModel GetEventByName(string eventName);
    }
}
