using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.Text;


namespace MUT_Service.Interface
{
    public interface ISportService
    {
        public List<SportModel> GetAllSports();
    }
}
