using MUT_DataAccess.DataContext;
using MUT_DataAccess.DataModels;
using MUT_MODELS;
using MUT_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MUT_Service.Implementation
{
    public class EventService : IEventService
    {
        private readonly MUTDbContext mUTDbContext;
        public EventService(MUTDbContext _mUTDbContext)
        {
            this.mUTDbContext = _mUTDbContext;
        }
        public List<EventModel> GetAllEvents()
        {
            using (mUTDbContext)
            {
                return mUTDbContext.Events.Select(x => new EventModel
                {
                    Name = x.Name,
                    Venue = x.Venue,
                    StartingTime = x.StartingTime,
                    EndingTime = x.EndingTime
                }).ToList();
            }
        }

        public EventModel GetEventByName(string eventName)
        {
            using (mUTDbContext)
            {
                return mUTDbContext.Events.Where(x => x.Name.Equals(eventName)).Select(x => new EventModel
                {
                    Name = x.Name,
                    Venue = x.Venue,
                    StartingTime = x.StartingTime,
                    EndingTime = x.EndingTime
                }).Single();
            }
        }

        public void InsertNewEvent(EventModel eventModel)
        {
            throw new NotImplementedException();
        }

        public void UpdateEvent(EventModel eventModel)
        {
            using(mUTDbContext)
            {
               
            }
        }
    }
}
