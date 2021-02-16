using Microsoft.AspNetCore.Mvc;
using MUT_DataAccess.DataContext;
using MUT_DataAccess.DataModels;
using MUT_MODELS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MUT_MVC.Controllers
{
    public class CoachController : Controller
    {
      
        private List<CoachModel> coachList;
        private readonly MUTDbContext mUTDbContext;
        private List<SportModel> sportList;
        public CoachController(MUTDbContext _mUTDbContext)
        {
            this.mUTDbContext = _mUTDbContext;
            coachList = new List<CoachModel>();
            sportList = new List<SportModel>();
        }

      
        public IActionResult CoachDashBoard()
        {
            return View();
        }


        public async Task<IActionResult> GetMyStudentsSports()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Coach/GetCoach"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    coachList = JsonConvert.DeserializeObject<List<CoachModel>>(apiResponse);
                }
            }
            return View(coachList);
        }

        public async Task<IActionResult> PostCoach() 
        {
            //Call all sport api
           
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Sport/GetSports"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    sportList = JsonConvert.DeserializeObject<List<SportModel>>(apiResponse); 
                    ViewBag.listofSport = sportList;
                }
            }
           
            //declare viewbag and assign
           return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostCoach(CoachModel coach)
        {

            using (var httpClient = new HttpClient())
            {
                ViewBag.listofSport = sportList;
                StringContent content = new StringContent(JsonConvert.SerializeObject(coach), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44330/api/Coach/PostCoach", content))
                {
                    ViewBag.listofSport = sportList;
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("GetAllCoaches");
                    }
                }
            }

            return View(coach);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoaches()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Coach/GetCoaches"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    coachList = JsonConvert.DeserializeObject<List<CoachModel>>(apiResponse);
                }
            }
            return View(coachList);
        }
    }
}