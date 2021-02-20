using Microsoft.AspNetCore.Mvc;
using MUT_DataAccess.DataModels;
using MUT_MODELS;
using MUT_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MUT_SPORT_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TrainingController : Controller
    {

        private readonly IStudentService studentService;
        private readonly ISportService sportService;
        ITrainingSchedule trainingSchedule;

        public TrainingController(IStudentService _studentService, ISportService _sportService, ITrainingSchedule trainingSchedule)
        {
            this.studentService = _studentService;
            this.sportService = _sportService;
            this.trainingSchedule = trainingSchedule;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentModel>> GetStudents()
        {
            return studentService.GetAllStudents();
        }

        [HttpGet]
        public ActionResult<IEnumerable<SportModel>> GetSport()
        {
            return sportService.GetAllSports();
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<TrainingSchedule>> GetSchedules(int id)
        {
            return trainingSchedule.GetTrainingScheduleBySportID(id);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
