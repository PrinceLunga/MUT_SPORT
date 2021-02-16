using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MUT_MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly Defaults _Default;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public StudentController( SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            
            _Default = new Defaults();
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> StudentIndex()
        {
            var registerSport = new List<StudentRegisterSportTeamsModel>();
            var studentSportModel = new List<StudentSportModel>();
            var sportList = new List<SportModel>();

            using (var httpClient = new HttpClient())
            {
                string username = "n@gmail.com";

                using (var response = await httpClient.GetAsync("https://localhost:44330/api/StudentSport/GetStudentSportsByEmail/" + username))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    studentSportModel = JsonConvert.DeserializeObject<List<StudentSportModel>>(apiResponse);
                }

                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Student/GetSport"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    sportList = JsonConvert.DeserializeObject<List<SportModel>>(apiResponse);
                }

                foreach (var item in sportList)
                {
                    var a = studentSportModel.Where(x => x.SportId == item.Id).SingleOrDefault();
                    if (a != null)
                    {
                        var b = new StudentRegisterSportTeamsModel
                        {
                            Id = item.Id,
                            Code = item.Code,
                            Image = item.Image,
                            Name = item.Name,
                            IsRegistered = true
                        };
                        registerSport.Add(b);
                    }
                    else
                    {
                        var b = new StudentRegisterSportTeamsModel
                        {
                            Id = item.Id,
                            Code = item.Code,
                            Image = item.Image,
                            Name = item.Name,
                            IsRegistered = false
                        };
                        registerSport.Add(b);
                    }
                }


                var studentSportrec = studentSportModel.Where(x => x.StudentId.Equals(username));


            }

            foreach (var resultObject in registerSport)
            {
                if (resultObject.IsRegistered == true)
                {
                    ViewBag.Data = "IsEnrolled";
                    break;
                }

            }
            return View(registerSport);
        }


        public async Task<IActionResult> Register(int sportId)
        {
            using (var httpClient = new HttpClient())
            {
                var student = new StudentSportModel
                {
                    StudentId = "n@gmail.com",
                    SportId = sportId,
                    DateEnrolled = DateTime.Now

                };
                StringContent content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44330/api/Student/EnrollSport", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        return View();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Deregister(int sportId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44330/api/Student/DeregisterToSport/" + sportId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        return View();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Profile(string username)
        {
            username = "n@gmail.com";
            ProfileRetreaval studData = new ProfileRetreaval();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/api/Student/GetStudentById/" + username))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    studData = JsonConvert.DeserializeObject<ProfileRetreaval>(apiResponse);

                }
            }
            return View(studData);
        }

        private string AttachFile(ProfileRetreaval studData)
        {
            int count = 0;
            string defaultImage = "";
            foreach (var file in Request.Form.Files)
            {

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                if(count == 1)
                {
                    studData.MedicalAidCardPic = ms.ToArray();
                }
                else
                {
                    studData.DisplayPicture = ms.ToArray();
                }
                count++;
                ms.Close();
                ms.Dispose();

            }
            if(studData.MedicalAidCardPic == null)
            {
                string imageDataURL = string.Format("data:image/jpeg;base64,{0}", _Default.DEFAULT_IMAGE);
                defaultImage  = imageDataURL;
            }
            return defaultImage;
        }

        [HttpPost]
        public async Task<IActionResult> Profile([FromForm] ProfileRetreaval studData)
        {
            string username = "n@gmail.com";

            using (var httpClient = new HttpClient())
            {
                IFormFile file = null;
                ViewBag.Image = AttachFile(studData);

                StringContent content = new StringContent(JsonConvert.SerializeObject(studData), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44330/api/Student/PutStudent", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        using (var response1 = await httpClient.GetAsync("https://localhost:44330/api/Student/GetStudentById/" + username))
                        {
                            string apiResponse1 = await response1.Content.ReadAsStringAsync();
                            studData = JsonConvert.DeserializeObject<ProfileRetreaval>(apiResponse1);

                        }
                        return View(studData);
                    }
                }
                return null;

            }
        }


       [HttpGet]
        public async Task<IActionResult> CreateAccount()
        {
          
            var residences = new List<ResidenceMvcController>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/api/Residence/GetAllResidences"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    residences = JsonConvert.DeserializeObject<List<ResidenceMvcController>>(apiResponse);
                    ViewBag.Residences = residences;
                }
            }
            return View(residences);
        }
        [HttpPost]
        public async void CreateAccount(StudentMvcModel model, string returnUrl = null)
        {
           
                returnUrl = returnUrl ?? Url.Content("~/");
                if (ModelState.IsValid)
                {
                    var user = new IdentityUser 
                    { 
                        UserName = model.Email, 
                        Email = model.Email 
                    };

                  var result = await _userManager.CreateAsync(user, model.Password); 

                if (result.Succeeded)
                {
                        using (var httpClient = new HttpClient())
                        {
                            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                            using (var response = await httpClient.PostAsync("https://localhost:44330/api/Student/PostStudent", content))
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                if (response.IsSuccessStatusCode)
                                {
                                    Url.Content("~/StudentIndex");
                                }
                            }
                        }
                }

            }
        }
    }
}
