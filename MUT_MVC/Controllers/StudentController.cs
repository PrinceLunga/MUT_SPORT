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

        public StudentController(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {

            _Default = new Defaults();
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult StudentDashBoard()
        {
            return View();
        }

        public async Task<IActionResult> StudentIndex()
        {
            var student = new List<StudentModel>();
            using (var httpClient = new HttpClient())
            {
                //string username = "n@gmail.com";
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Student/GetStudents"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    student = JsonConvert.DeserializeObject<List<StudentModel>>(apiResponse);
                }
                return View(student);

               /* foreach (var item in sportList)
                {
                    var a = studentSportModel.Where(x => x.SportId == item.Id).SingleOrDefault();
                    if (a != null)
                    {
                        var b = new StudentRegisterSportTeamsModel
                        {
                            Id = item.Id,
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
                            Image = item.Image,
                            Name = item.Name,
                            IsRegistered = false
                        };
                        registerSport.Add(b);
                    }
                }*/


              //  var studentSportrec = studentSportModel.Where(x => x.StudentId.Equals(username));


            }

           
        }


        public async Task<IActionResult> Register(int sportId, int studentId, string Username)
        {
            using (var httpClient = new HttpClient())
            {
                var student = new StudentSportModel
                {
                    StudentId = studentId,
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
                if (count == 1)
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
            if (studData.MedicalAidCardPic == null)
            {
                string imageDataURL = string.Format("data:image/jpeg;base64,{0}", _Default.DEFAULT_IMAGE);
                defaultImage = imageDataURL;
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

        public ViewResult CreateAccount() => View();

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromForm] AddStudentModel model)
        {
            string _MedicalAidCardPic = "";
            string _DisplayPicture = "";
            var response = new HttpResponseMessage();
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };

           
            using (var memoryStream = new MemoryStream())
            {
                await model.DisplayPicture.CopyToAsync(memoryStream);
                var a = memoryStream.ToArray();
                _DisplayPicture = Convert.ToBase64String(a);

            }

            
            using (var memoryStream = new MemoryStream())
            {
                await model.MedicalAidCardPic.CopyToAsync(memoryStream);
                var a = memoryStream.ToArray();
                _MedicalAidCardPic = Convert.ToBase64String(a);

            }

            var _StudentModel = new PostStudent
            {
                Accomodation = model.Accomodation,
                ConfirmPassword = model.ConfirmPassword,
                DateCreated = model.DateCreated,
                DateDeleted = model.DateDeleted,
                DateModified = model.DateModified,
                DisplayPicture = _DisplayPicture,
                Email = model.Email,
                FirstName = model.FirstName,
                Gender = model.Gender,
                HasMedicalAid = model.HasMedicalAid,
                MedicalAidCardPic = _MedicalAidCardPic,
                LastName = model.LastName,
                MedicalAidNumber = model.MedicalAidNumber,
                NextOfKinFullnames = model.NextOfKinFullnames,
                NextOfKinPhoneNumber = model.NextOfKinPhoneNumber,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                Qualification = model.Qualification,
                StudentNumber = model.StudentNumber,
                StudyLevel = model.StudyLevel
            };

            var formDataContent = new MultipartFormDataContent();
            formDataContent.Add(new StringContent(_StudentModel.DateCreated.ToString()), "datecreated");
            formDataContent.Add(new StringContent(_StudentModel.DateDeleted.ToString()), "datedeleted");
            formDataContent.Add(new StringContent(_StudentModel.DateModified.ToString()), "datemodified");
            formDataContent.Add(new StringContent(_StudentModel.ConfirmPassword), "confirmpassword");
            formDataContent.Add(new StringContent(_StudentModel.Password), "password");
            formDataContent.Add(new StringContent(_StudentModel.DisplayPicture), "DisplayPicture");
            formDataContent.Add(new StringContent(_StudentModel.MedicalAidCardPic), "MedicalAidCardPic");
            formDataContent.Add(new StringContent(_StudentModel.LastName), "lastname");
            formDataContent.Add(new StringContent(_StudentModel.FirstName), "firstname");
            formDataContent.Add(new StringContent(_StudentModel.Email), "email");
            formDataContent.Add(new StringContent(_StudentModel.Gender), "gender");
            formDataContent.Add(new StringContent(_StudentModel.HasMedicalAid.ToString()), "HasMedicalAid");
            formDataContent.Add(new StringContent(_StudentModel.MedicalAidNumber), "medicalaidnumber");
            formDataContent.Add(new StringContent(_StudentModel.StudyLevel), "studylevel");
            formDataContent.Add(new StringContent(_StudentModel.StudentNumber), "studentnumber");
            formDataContent.Add(new StringContent(_StudentModel.PhoneNumber), "phonenumber");
            formDataContent.Add(new StringContent(_StudentModel.Qualification), "qualification");
            formDataContent.Add(new StringContent(_StudentModel.NextOfKinPhoneNumber), "nextofkinphonenumber");
            formDataContent.Add(new StringContent(_StudentModel.NextOfKinFullnames), "nextofKinfullnames");
            formDataContent.Add(new StringContent(_StudentModel.Accomodation), "accomodation");

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                using (var httpClient = new HttpClient())
                {
                    response = await httpClient.PostAsync("https://localhost:44330/Api/Student/PostStudent", formDataContent);
                    var data = await response.Content.ReadAsStringAsync();
                    response.EnsureSuccessStatusCode();
                }
                _userManager.AddToRoleAsync(user, "Student").Wait();
            }
            return RedirectToAction(nameof(StudentIndex));
        }
    }

}
