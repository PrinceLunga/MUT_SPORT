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
                    //EventPicture = x.EventPicture,
                    StartingDate = x.StartingDate.Date
                }).ToList();
            }
        }

        public UpComingEventsModel GetEventById(int id)
        {
            return mUTDbContext.UpComingEvents.Where(x => x.Id == id).Select(x => new UpComingEventsModel
            {
                Id = x.Id,
                Venue = x.Venue,
                DateClosed = x.DateClosed,
                DateCreated = x.DateCreated,
                DateModified = x.DateModified,
                Descriptions = x.Descriptions,
                EndingDate = x.EndingDate.Date,
                //EventPicture = x.EventPicture,
                StartingDate = x.StartingDate.Date
            }).SingleOrDefault();
        }
    

        /*public UpComingEventsModel GetEventByName(string eventName)
        {
            using (mUTDbContext)
            {
                return mUTDbContext.UpComingEvents.Where(x => x.Name.Equals(eventName)).Select(x => new UpComingEventsModel
                {
                    Id = x.Id,
                    Venue = x.Venue,
                    DateClosed = x.DateClosed,
                    DateCreated = x.DateCreated,
                    DateModified = x.DateModified,
                    Descriptions = x.Descriptions,
                    EndTime = x.EndTime,
                    EventDate = x.EventDate,
                    StartingTime = x.StartingTime
                }).Single();
            }
        }*/

        public UpComingEvent InsertNewEvent(UpComingEventsModel eventModel)
        {
            using (mUTDbContext)
            {
                var _event = new UpComingEvent
                {
                    Id = eventModel.Id,
                    Venue = eventModel.Venue,
                    Descriptions = eventModel.Descriptions,
                    StartingDate = eventModel.StartingDate,
                    EventPicture = eventModel.EventPicture,
                    EndingDate = eventModel.EndingDate,
                    SportId = 2,
                    DateModified = eventModel.DateModified,
                    DateCreated = DateTime.Now,
                    DateClosed = eventModel.DateClosed
                };
                mUTDbContext.Add(_event);
                if (mUTDbContext.SaveChanges() == 1)
                {
                    return _event;
                }
                return new UpComingEvent();
            }


        }

       /* public void UpdateEvent(UpComingEventsModel eventModel)
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
        }*/

        public UpComingEvent UpdateEvent(UpComingEventsModel eventModel)
        {
            using (mUTDbContext)
            {
                var _event = mUTDbContext.UpComingEvents.Find(eventModel.Id);
           
                _event.Venue = eventModel.Venue;
                _event.Descriptions = eventModel.Descriptions;
                _event.EventPicture = eventModel.EventPicture;
                _event.StartingDate = eventModel.StartingDate;
                _event.EndingDate = eventModel.EndingDate;
                mUTDbContext.UpComingEvents.Update(_event);

                if (mUTDbContext.SaveChanges() == 1)
                    return _event;
            }
                return new UpComingEvent();
        }

        public void DeleteEvent(int id) 
        {
            using (mUTDbContext)
            {
                var eventModel = mUTDbContext.UpComingEvents.Find(id);

                if (eventModel != null)
                {
                    mUTDbContext.UpComingEvents.Remove(eventModel);
                    mUTDbContext.SaveChanges();
                }        
            }
        }
    }
}