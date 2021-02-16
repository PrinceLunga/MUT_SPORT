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
    public class AdminController : ControllerBase
    {

        public readonly IAdminService adminService;
        public AdminController(IAdminService _adminService )
        {
            this.adminService = _adminService;
        }

        public ActionResult<IEnumerable<AdminModel>> GetAdmin()
        {
            return adminService.GetAdmin();
        }
        
        [HttpPost]
        public async Task<ActionResult<AdminModel>> PostAdmin([FromBody] AdminModel model)
        {
            adminService.AddAdmin(model);
            return CreatedAtAction("GetAdmin", new {id = model.Id }, model);
        }

    }
}
