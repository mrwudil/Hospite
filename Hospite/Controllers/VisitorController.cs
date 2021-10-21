using Hospite.Data;
using Hospite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospite.Controllers
{
    public class VisitorController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public VisitorController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;

        }

        public async Task<IActionResult> Index()
        {
            var id = HttpContext.Session.GetString("Id");
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Login", "Account");
            }

            var user = await _userManager.FindByIdAsync(id);
            if(user == null)
            {
                return BadRequest();
            }

            var res = new UserViewModel
            {
                Name = user.Name,
                Phone = user.PhoneNumber,
                Email = user.Email,

                GetSchedules = user.Schedules

            };


            return View(res);
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var Id = HttpContext.Session.GetString("Id");
            if (string.IsNullOrEmpty(Id))
            {
                return RedirectToAction("Login", "Account");
            }

            var user = await _userManager.FindByIdAsync(Id);
            if(user == null)
            {
                return BadRequest();
            }

            var res = new UserViewModel
            {
                Name = user.Name,
                Phone = user.PhoneNumber,
                Email = user.Email,

                GetSchedules = user.Schedules
            };

            return View(res);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] UserViewModel model)
        {
            return RedirectToAction("Profile");
        }
    }
}
