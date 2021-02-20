using Microsoft.AspNetCore.Mvc;
using MUT_MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MUT_MVC.Controllers
{
    public class TrainingController : Controller
    {
        
        public async Task<IActionResult> TrainingSchedules(int id)
        {
            var schedules = new List<TrainingMvcModels>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Training/GetSchedules/"+id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    schedules = JsonConvert.DeserializeObject<List<TrainingMvcModels>>(apiResponse);
                }
            }
            return View(schedules);
        }
    }
}
