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
                  
                    StartingTime = x.StartingTime,
                    EndingTime = x.EndingTime,
                    Name = x.Name,
                    Venue = x.Venue
                   
                }).ToList();

            } 
        }
        public List<UpComingEventsModel> GetEventsBySportId(int id)
        {
            using (mUTDbContext)
            {
                return mUTDbContext.UpComingEvents.Where(x => x.SportId == id).Select(x => new UpComingEventsModel
                {
                    Id = x.Id,
                    Venue = x.Venue,
                    DateClosed = x.DateClosed,
                    DateCreated = x.DateCreated,
                    DateModified = x.DateModified,
                    Descriptions = x.Descriptions,
                    EndingDate = x.EndingDate.Date,
                    EventPicture = x.EventPicture,
                    StartingDate = x.StartingDate.Date
                }).ToList();
            }
        }

       
public void InsertNewEvent(EventModel Model)
        {
            using (mUTDbContext)
            {
                var _event = new Event
                {
                   
                  
                    StartingTime = Model.StartingTime,
                    EndingTime = Model.EndingTime,
                    Name = Model.Name,
                    Venue = Model.Venue
                };
                mUTDbContext.Events.Add(_event);
                mUTDbContext.SaveChanges();
            }
    }

        

        public void UpdateEvent(UpComingEventsModel eventModel)
        {
            using (mUTDbContext)
            {
                var _event = mUTDbContext.UpComingEvents.Find(eventModel.Id);

                _event.Id = eventModel.Id;
                _event.Venue = eventModel.Venue;
                _event.DateClosed = eventModel.DateClosed;
                _event.DateCreated = eventModel.DateCreated;
                _event.DateModified = eventModel.DateModified;
                _event.Descriptions = eventModel.Descriptions;
                _event.EndingDate = eventModel.EndingDate;
                _event.EventPicture = eventModel.EventPicture;
                _event.StartingDate = eventModel.StartingDate;
                mUTDbContext.SaveChanges();

            }
        }
    }
}