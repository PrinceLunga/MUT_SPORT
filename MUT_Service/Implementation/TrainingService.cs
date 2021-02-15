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
    public class TrainingService : ITrainingSchedule
    {
        private readonly MUTDbContext dbContext;

        public TrainingService(MUTDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public TrainingSchedule AddTrainingSchedule(TrainingSchedule model)
        {
            using (dbContext)
            {
                var trainShecule = new TrainingSchedule
                {
                    Venue = model.Venue,
                    StartTime = model.StartTime,
                    DateOfSession = model.DateOfSession,
                    FinishTime = model.FinishTime
                };

                dbContext.TrainingSchedules.Add(trainShecule);
                if (dbContext.SaveChanges() == 1)
                {
                    return trainShecule;
                }
            }
            return new TrainingSchedule();
        }

        public List<TrainingSchedule> GetTrainingScheduleBySportID(int sportId)
        {
            return dbContext.TrainingSchedules.Where(x => x.Id == sportId).Select(x => new TrainingSchedule 
            {
                Id = x.Id,
                Venue = x.Venue,
                DateOfSession = x.DateOfSession,
                StartTime = x.StartTime,
                FinishTime = x.FinishTime
            }).ToList();
        }
    }
}
