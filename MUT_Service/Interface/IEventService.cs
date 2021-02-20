using MUT_DataAccess.DataModels;
using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_Service.Interface
{
    public interface IEventService
    {
        public List<UpComingEventsModel> GetEventsBySportId(int id);
        public UpComingEventsModel GetEventById(int id);
        public UpComingEvent InsertNewEvent(UpComingEventsModel eventModel);
        public UpComingEvent UpdateEvent(UpComingEventsModel model);
        public void DeleteEvent(int id);
    }
}
