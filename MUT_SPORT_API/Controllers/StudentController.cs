using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MUT_MODELS;
using MUT_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MUT_SPORT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IStudentService studentService;

        public StudentController(IStudentService _studentService)
        {
            this.studentService = _studentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentModel>> GetStudents()
        {
            return studentService.GetAllStudents();
        }

        [HttpPost]
        public async Task<ActionResult<StudentModel>> PostStudent(StudentModel model)
        {
            studentService.AddStudent(model);
            return CreatedAtAction("GetStudents", new { id = model.Id }, model);
        }

        [HttpGet("{id}")]
        public ActionResult<StudentModel> GetStudentById(string id)
        {
            var student = studentService.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        [HttpPut("{id}")]
        [AcceptVerbs("POST", "PUT")]
        public ActionResult<StudentModel> PutStudent(int id, StudentModel model)
        {
            try
            {
                if ((model == null) || (model.Id == 0))
                {
                    return NotFound();
                }
                studentService.UpdateProfile(model);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id))
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

        private bool GroupExists(int id)
        {
            return studentService.StudentExists(id);
        }

        [HttpGet]
        public ActionResult<IEnumerable<TrainingScheduleModel>> GetTrainingSchedules()
        {
            return studentService.GetTrainingSchedules();
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventModel>> GetUpcomingEvents()
        {
            return studentService.GetAllUpcomingEvents();
        }

    }
}
