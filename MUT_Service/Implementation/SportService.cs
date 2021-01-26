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


    }
}
