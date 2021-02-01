using Microsoft.AspNetCore.Mvc;
using MUT_MODELS;
using MUT_MVC.Models;
using MUT_Service.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MUT_MVC.Controllers
{
    public class SportController : Controller
    {
        private readonly ISportService sportService;
        private List<SportModel> sportList;

        public SportController(ISportService _sportService)
        {
            this.sportService = _sportService;
            sportList = new List<SportModel>();
        }
        public async Task<IActionResult> GetSports()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Sport/GetSports"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    sportList = JsonConvert.DeserializeObject<List<SportModel>>(apiResponse);
                }
            }
            return View(sportList);
        }

        public ViewResult AddSport() => View();

        [HttpPost]
        public async Task<IActionResult> AddSport([FromForm]  AddSportModel model)
        {
            //var a = Object;
            string Image = "";
            using (var httpClient = new HttpClient())
            {
                MultipartFormDataContent multiContent = new MultipartFormDataContent();

                using (var memoryStream = new MemoryStream())
                {
                    await model.Image.CopyToAsync(memoryStream);
                    var a = memoryStream.ToArray();
                    Image = Convert.ToBase64String(a);

                }

                var response = new HttpResponseMessage();

                var sport = new AddSportInnerModel
                {
                    Code = model.Code,
                    Name = model.Name,
                    Image = Image
                };

                var formDataContent = new MultipartFormDataContent();
                formDataContent.Add(new StringContent(sport.Image), "Image");
                formDataContent.Add(new StringContent(sport.Code), "Code");
                formDataContent.Add(new StringContent(sport.Name), "Name");

                response = await httpClient.PostAsync("https://localhost:44330/Api/Sport/PostSport", formDataContent);

                var data = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
