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
    public class AdminService : IAdminService
    {
        public readonly MUTDbContext mUTDbContext;
        public AdminService(MUTDbContext _mUTDbContext)
        {
            this.mUTDbContext = _mUTDbContext;
        }


        public void AddAdmin(AdminModel model)
        {
            using(mUTDbContext)
            {
                var admin = new Admin
                {
                    EmployeeNumber = model.EmployeeNumber,
                    Fullname = model.Fullname,
                    Surname = model.Surname,
                    Gender = model.Gender,
                    Address = model.Address,
                    Email = model.Email,
                    Password = model.Password
                };
                mUTDbContext.Admins.Add(admin);
                mUTDbContext.SaveChanges();
            };
        }

        public bool AdmintExist(int id)
        {
            throw new NotImplementedException();
        }

        public List<AdminModel> GetAdmin()
        {
           using(mUTDbContext)
            {
                return mUTDbContext.Admins.Select(x => new AdminModel
                {
                    EmployeeNumber = x.EmployeeNumber,
                    Fullname = x.Fullname,
                    Surname = x.Surname,
                    Gender = x.Gender,
                    Address = x.Address,
                    Email = x.Email,
                    Password = x.Password
                }).ToList();
            }
        }

        public AdminModel GetAdminID(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAdmin(GameResultModel gameResultModel)
        {
            throw new NotImplementedException();
        }
    }
}
