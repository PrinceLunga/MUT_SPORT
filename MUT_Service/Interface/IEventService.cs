using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_Service.Interface
{
    public interface IEventService
    {
        public List<UpComingEventsModel> GetEventsBySportId(int id);
        public void InsertNewEvent(UpComingEventsModel eventModel);
        public void UpdateEvent(UpComingEventsModel eventModel);
        public List<UpComingEventsModel> GetAllEvents();
    }
}
