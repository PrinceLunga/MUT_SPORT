using Microsoft.AspNetCore.Mvc;
using MUT_MODELS;
using MUT_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MUT_MVC.Controllers
{
    public class CoachController : Controller
    {

        private readonly ICoachService coachService;
        private List<CoachModel> coachList;

        public CoachController(ICoachService _coachService)
        {
            this.coachService = _coachService;
            coachList = new List<CoachModel>();
        }
        public async Task<IActionResult> Insert  ()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Sport/GetSports"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    coachList = JsonConvert.DeserializeObject<List<SportModel>>(apiResponse);
                }
            }
            return View(coachList);
        }

        public ViewResult AddSport() => View();

        [HttpPost]
        public async Task<IActionResult> AddSport([FromForm] AddSportModel model)
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
