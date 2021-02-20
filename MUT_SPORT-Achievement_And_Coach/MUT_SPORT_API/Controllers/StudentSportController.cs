using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class StudentSportController : ControllerBase
    {
        private readonly IStudentSportService studentSportService;

        public StudentSportController(IStudentSportService studentSportService)
        {
            this.studentSportService = studentSportService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentSportModel>> GetAllStudentSport()
        {
            return studentSportService.GetStudentSports();
        }

        [HttpGet("{email}")]
        public ActionResult<IEnumerable<StudentSportModel>> GetStudentSportsByEmail(string email)
        {
            return studentSportService.GetStudentSportsByEmail(email);
        }
    }
}
