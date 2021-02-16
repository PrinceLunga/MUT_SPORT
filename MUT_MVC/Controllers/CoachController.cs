using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private List<SportModel> sportList;

        public CoachController(RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
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
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Sport/GetSports"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    sportList = JsonConvert.DeserializeObject<List<SportModel>>(apiResponse);
                }
            }
            return View(sportList);
        }

        public IActionResult RegisterCoach()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterCoach(CoachModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.EmailAddress,
                    Email = model.EmailAddress
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Administrator").Wait();

                    CoachModel receivedCoach = new CoachModel();
                    using (var httpClient = new HttpClient())
                    {
                        StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                        using (var response = await httpClient.PostAsync("https://localhost:44330/Api/Coach/InsertNewCoach", content))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            receivedCoach = JsonConvert.DeserializeObject<CoachModel>(apiResponse);
                        }
                    }
                }

            }
            else
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(CoachDashBoard));
        }

    }
}
