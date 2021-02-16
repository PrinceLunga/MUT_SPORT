using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_Service.Interface
{
    public interface IAdminService
    {
        public void AddAdmin(AdminModel model);
        public List<AdminModel> GetAdmin();
        public AdminModel GetAdminID(int Id);
        public void UpdateAdmin(GameResultModel gameResultModel);
        bool AdmintExist(int id);

    }
}
