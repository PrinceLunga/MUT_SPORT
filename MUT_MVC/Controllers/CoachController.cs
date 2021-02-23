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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public CoachController(UserManager<IdentityUser> _userManager,
            SignInManager<IdentityUser> _signInManager)
        {
            this._userManager = _userManager;
            this._signInManager = _signInManager;
        }

        public IActionResult CoachDashBoard()
        {
            return View();
        }
        public async Task<IActionResult> GetCoachById(int id)
        {
            var coaches = new List<CoachModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Coache/GetCoachById/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    coaches = JsonConvert.DeserializeObject<List<CoachModel>>(apiResponse);
                }
            }
            return View(coaches);
        }

        public async Task<IActionResult> GetAllCoaches()
        {
            var coaches = new List<CoachModel>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Coach/GetCoaches"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    coaches = JsonConvert.DeserializeObject<List<CoachModel>>(apiResponse);
                }
            }
            return View(coaches);
        }

        public async Task<ViewResult> CreateCoach()
        {
            var Sports = new List<SportModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Sport/GetSports"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Sports = JsonConvert.DeserializeObject<List<SportModel>>(apiResponse);
                    ViewBag.Sports = Sports;
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoach(CoachModel model)
        {
            var user = new IdentityUser
            {
                UserName = model.EmailAddress,
                Email = model.EmailAddress
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Coach");
                var _Coach = new CoachModel();

                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("https://localhost:44330/api/Coach/InsertNewCoach", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        _Coach = JsonConvert.DeserializeObject<CoachModel>(apiResponse);
                    }
                }
                return RedirectToAction(nameof(GetAllCoaches));
            }
            else
                return View();
        }

        public  ViewResult LoginCoach() => View();

        [HttpPost]
        public async Task<IActionResult> LoginCoach(LoginModel model)
        {
            var _Coach = new CoachModel();
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(GetAllCoaches));
                }
                return View();
            }
            else
                return View();

        }

    }
}