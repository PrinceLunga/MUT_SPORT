using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MUT_MODELS;
using MUT_MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MUT_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext applicationDbContext;

        public HomeController(UserManager<IdentityUser> _userManager,
            SignInManager<IdentityUser> _signInManager,
            ApplicationDbContext applicationDbContext)
        {
            this._userManager = _userManager;
            this._signInManager = _signInManager;
            this.applicationDbContext = applicationDbContext;
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {

                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var _user = await _userManager.FindByNameAsync(model.Email);

                    var role = applicationDbContext.UserRoles.SingleOrDefault(x => x.UserId.Equals(_user.Id));
                    var ExistingRole = applicationDbContext.Roles.SingleOrDefault(x => x.Id == role.RoleId); //_userManager.IsInRoleAsync(_user, "Student");
                    var CoachExist = _userManager.IsInRoleAsync(_user, "Coach");
                    var AdministratorExist = _userManager.IsInRoleAsync(_user, "Administrator");

                    if (role != null)
                    {
                        return RedirectToAction(ExistingRole.Name+"DashBoard", ExistingRole.Name);
                    }
                    return View();

                }
                return View();
            }
            else
                return View();
        }
    }
}
