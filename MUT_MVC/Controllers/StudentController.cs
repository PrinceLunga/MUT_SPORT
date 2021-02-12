using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MUT_MODELS;
using MUT_Service.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MUT_MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private List<StudentModel> students;
        private StudentModel _student;

        public StudentController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            students = new List<StudentModel>();
            _student = new StudentModel();
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Student/GetStudents"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    students = JsonConvert.DeserializeObject<List<StudentModel>>(apiResponse);
                }
            }
            return View(students);
        }

        public ViewResult PostStudent() => View();

        [HttpPost]
        public async Task<IActionResult> PostStudent(StudentModel student)
        {

            var user = new IdentityUser
            {
                UserName = student.EmailAddress,
                Email = student.EmailAddress
            };

            var result = await _userManager.CreateAsync(user, student.Password);

            if (result.Succeeded)
            {
                string Role = "Student";

                _userManager.AddToRoleAsync(user, Role).Wait();
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("https://localhost:44330/api/Student/PostStudent", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        //_student = JsonConvert.DeserializeObject<StudentModel>(apiResponse);
                    }
                }
            }
            return RedirectToAction(nameof(GetStudents));
        }

        public async Task<IActionResult> UpdateStudent(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/api/Student/GetStudentById" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _student = JsonConvert.DeserializeObject<StudentModel>(apiResponse);
                }
            }
            return View(_student);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGroup(StudentModel studentModel)
        {
            using (var httpClient = new HttpClient())
            {
                string serailizedStudent = JsonConvert.SerializeObject(studentModel);

                var inputMessage = new HttpRequestMessage
                {
                    Content = new StringContent(serailizedStudent, Encoding.UTF8, "application/json")
                };

                inputMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage message = httpClient.PutAsync("https://localhost:44330/api/Student/PutStudent", inputMessage.Content).Result;

                if (!message.IsSuccessStatusCode)
                    throw new ArgumentException(message.ToString());

                return RedirectToAction("GetStudents");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTrainingSchedules()
        {
            var trainingSchedules = new List<TrainingScheduleModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Student/GetTrainingSchedules"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    trainingSchedules = JsonConvert.DeserializeObject<List<TrainingScheduleModel>>(apiResponse);
                }
            }
            return View(trainingSchedules);
        }

        [HttpGet]
        public async Task<IActionResult> GetUpcomingEvents()
        {
            var _eventsModel = new List<EventModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44330/Api/Student/GetUpcomingEvents"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _eventsModel = JsonConvert.DeserializeObject<List<EventModel>>(apiResponse);
                }
            }
            return View(_eventsModel);
        }
    }
}
