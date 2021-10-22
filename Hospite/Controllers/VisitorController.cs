using Hospite.Data;
using Hospite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            var user = await _userManager.Users.Include(x => x.Address).FirstOrDefaultAsync(x=> x.Id == Id);
            if(user == null)
            {
                return BadRequest();
            }

            var res = new UserViewModel
            {
                Name = user.Name,
                Phone = user.PhoneNumber,
                Email = user.Email,
                Gender = user.Gender,
                Address = user.Address,

                GetSchedules = user.Schedules
            };

            return View(res);
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var id = HttpContext.Session.GetString("Id");
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Login", "Account");
            }

            var user = await _userManager.Users.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return BadRequest();
            }

            var res = new UserViewModel
            {
                Name = user.Name,
                Phone = user.PhoneNumber,
                Email = user.Email,
                Address = user.Address,
                Gender = user.Gender,
                IsAvailable = user.IsAvailble,

                GetSchedules = user.Schedules

            };


            return View(res);
        }




        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] UserViewModel model)
        {
            return RedirectToAction("Profile");
        }



        [HttpGet]
        public async Task<IActionResult> BookEmployee()
        {
            var userList = new List<EmpListViewModel>();
            var listOfEmp =await _userManager.GetUsersInRoleAsync("Employee");
            foreach (var user in listOfEmp)
            {

                var emp = new EmpListViewModel
                {
                    Name = user.Name,
                    Email = user.Email,
                    IsAvailable = user.IsAvailble

                };
                userList.Add(emp);
            }
            return View(userList);
        }


        [HttpPost]
        public async Task<IActionResult> BookEmployee([FromForm] UserViewModel model)
        {
            return RedirectToAction("Profile");
        }


    }
}
