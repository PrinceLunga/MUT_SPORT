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
    public class SportService : ISportService
    {
        private readonly MUTDbContext _dbContext;

        public SportService(MUTDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public List<SportModel> GetAllSports()
        {
            using (_dbContext)
            {
               return _dbContext.Sports.Select(x => new SportModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    Image = x.Image

                }).ToList();   
            }
        }

        public SportModel GetSportById(int Id)
        {
            using (_dbContext)
            {
                return _dbContext.Sports.Where(x => x.Id == Id).Select(b => new SportModel
                {
                    Id = b.Id,
                    Code = b.Code,
                    Name = b.Name,
                    Image = b.Image
                }).SingleOrDefault();
            }
        }

        public void InsertNewSport(SportModel model)
        {
            using (_dbContext)
            {
                var sport = new Sport
                {
                    Name = model.Name,
                    Code = model.Code,
                    Image = model.Image
                };
                _dbContext.Sports.Add(sport);
                _dbContext.SaveChanges();
            }
        }

        public bool SportExists(int id)
        {
            using (_dbContext)
            {
                var sport = _dbContext.Sports.Find(id);

                if (sport != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public SportModel UpdateSport(SportModel model)
        {
            using (_dbContext)
            {
                var sport = _dbContext.Sports.Find(model.Id);

                if(sport != null)
                {
                    sport.Name = model.Name;
                    sport.Code = model.Code;
                    sport.Image = model.Image;

                    _dbContext.SaveChanges();
                    return model;
                }
                else
                {
                    return new SportModel();
                }
            }
        }
    }
}
