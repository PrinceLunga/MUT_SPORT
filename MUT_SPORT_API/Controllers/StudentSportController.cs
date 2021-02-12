using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MUT_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MUT_SPORT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSportController : ControllerBase
    {
        private readonly IStudentSportService studentSports;

        public StudentSportController(IStudentSportService _studentSports)
        {
            this.studentSports = _studentSports;
        }
    }
}
