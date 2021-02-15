﻿using MUT_DataAccess.DataContext;
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
                    EventPicture = x.EventPicture,
                    StartingDate = x.StartingDate.Date
                }).ToList();
            }
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

        public void InsertNewEvent(UpComingEventsModel eventModel)
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
                    DateModified = eventModel.DateModified,
                    DateCreated = eventModel.DateCreated,
                    DateClosed = eventModel.DateClosed
                };
                mUTDbContext.Add(_event);
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