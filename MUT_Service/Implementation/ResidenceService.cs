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
    public class ResidenceService : IResidence
    {
        private readonly MUTDbContext mUTDbContext;
        public ResidenceService(MUTDbContext mUTDbContext)
        {
            this.mUTDbContext = mUTDbContext;
        }

        public List<ResModel> GetResidences()
        {
            using (mUTDbContext)
            {
                return mUTDbContext.Residences.Select(x => new ResModel
                {
                    ResId = x.ResId,
                    Name = x.Name,
                    isInMainCamp = x.isInMainCamp,
                    Location = x.Location

                }).ToList();
            }
        }
    }
}
