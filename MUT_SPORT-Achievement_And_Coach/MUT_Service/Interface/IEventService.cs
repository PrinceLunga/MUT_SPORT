using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_Service.Interface
{
    public interface IEventService
    {
        public List<UpComingEventsModel> GetEventsBySportId(int id);
        public void InsertNewEvent(EventModel Model);
        public List<EventModel> GetAllEvents();
    }
}
