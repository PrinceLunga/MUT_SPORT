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

        public bool EventExists(int id)
        {
            using(mUTDbContext)
            {
                var _Event = mUTDbContext.Events.Find(id);

                if(_Event == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
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
            using (mUTDbContext)
            {
                var _event = new Event
                {
                    Id = eventModel.Id,
                    Name = eventModel.Name,
                    Venue = eventModel.Venue,
                    StartingTime = eventModel.StartingTime,
                    EndingTime = eventModel.EndingTime
                };
                mUTDbContext.Add(_event);
                mUTDbContext.SaveChanges();
            }


        }

        public void UpdateEvent(EventModel eventModel)
        {
            using (mUTDbContext)
            {
                var _event = mUTDbContext.Events.Find(eventModel.Id);

                _event.Name = eventModel.Name;
                _event.Venue = eventModel.Venue;
                _event.StartingTime = eventModel.StartingTime;
                _event.EndingTime = eventModel.EndingTime;
                mUTDbContext.SaveChanges();

            }
        }
    }



}