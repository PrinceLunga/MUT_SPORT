using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.Text;


namespace MUT_Service.Interface
{
    public interface ISportService
    {
        public List<SportModel> GetAllSports();
        public void InsertNewSport(SportModel model);
        public SportModel GetSportById(int Id);
        public SportModel UpdateSport(SportModel model);
        public bool SportExists(int id);


    }
}
