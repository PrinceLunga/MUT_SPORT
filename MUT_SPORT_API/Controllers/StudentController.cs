using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class StudentController : ControllerBase
    {

        private readonly IStudentService studentService;
        private readonly ISportService sportService;
        private readonly IStudentSportService ssService;


        public StudentController(IStudentService studentService, ISportService sportService, IStudentSportService ssService)
        {
            this.studentService = studentService;
            this.sportService = sportService;
            this.ssService = ssService;
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

        [HttpPost]
        public async Task<ActionResult<StudentModel>> PostStudent(StudentModel model)
        {
            studentService.AddStudent(model);
            return CreatedAtAction("GetStudents", new { id = model.StudentNumber }, model);
        }

        [HttpPost]
        public async Task<ActionResult<StudentSport>> EnrollSport([FromForm]StudentSportModel model)
        {
            if (ModelState.IsValid)
                return studentService.RegisterSport(model);
            else
                return new StudentSport();
        }

        [HttpGet("{username}")]
        public ActionResult<StudentModel> GetStudentById(string username)
        {
            var student = studentService.GetStudentById(username);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        [HttpPut("{username}")]
        [AcceptVerbs("POST", "PUT")]
        public ActionResult<StudentModel> PutStudent(StudentModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return NotFound();
                }
                studentService.UpdateProfile(model);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(model.Email))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return model;
        }

        private bool GroupExists(string username)
        {
            return studentService.StudentExists(username);
        }

        [HttpGet]
        public ActionResult<IEnumerable<TrainingScheduleModel>> GetTrainingSchedules()
        {
            return studentService.GetTrainingSchedules();
        }

        [HttpGet]
        public ActionResult<IEnumerable<UpComingEventsModel>> GetUpcomingEvents()
        {
            return studentService.GetAllUpcomingEvents();
        }

        [HttpDelete("{sportId}")]
        public void DeregisterToSport(int sportId)
        {
            if (sportId != 0)
            {
                ssService.DeregisterSport(sportId);
            }
        }

    }
}
