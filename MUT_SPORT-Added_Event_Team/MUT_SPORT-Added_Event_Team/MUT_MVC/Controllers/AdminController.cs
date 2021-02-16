using Microsoft.AspNetCore.Mvc;
using MUT_MODELS;
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
    public class AdminController : Controller
    {
        public List<AdminModel> AdminResultlist;
        public AdminController ()
        {
            this.AdminResultlist = new List<AdminModel>();
        }

        public async Task<IActionResult> GetAdmin()
        {
            using(var HttpClient = new HttpClient())
            {
                using( var response = await HttpClient.GetAsync("https://localhost:44330/Api/Admin/GetAdmin"))
                    {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    AdminResultlist = JsonConvert.DeserializeObject<List<AdminModel>>(apiResponse);
                    }
            }
            return View(AdminResultlist);
        }

        public ViewResult PostAdmin() => View();

        [HttpPost]
        public async Task<IActionResult> PostAdmin(AdminModel admin)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(admin), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44330/Api/Admin/PostAdmin", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction(nameof(GetAdmin));
        }
    }
}
