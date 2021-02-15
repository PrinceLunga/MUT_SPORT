using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MUT_MVC.Controllers
{
    public class ModalController : Controller
    {
        public IActionResult SportRegistered()
        {
            return View();
        }
    }
}
