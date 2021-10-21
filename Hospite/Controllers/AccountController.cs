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
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
                
        }
       
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        } 
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login([FromForm]LoginViewModel model)
        {
            ViewBag.LoginErrMsg = false;
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user == null)
            {
                return null;
            }

            var role = await _userManager.GetRolesAsync(user);

            HttpContext.Session.SetString("Id",user.Id);
            HttpContext.Session.SetString("role",role[0]);


            if (role.Contains("Admin"))
            {
                return RedirectToAction("Admin", "Dashboard", new
                {
                    Id = user.Id
                }
                );
            }

            if(role.Contains("Customer"))
            {
                return RedirectToAction("Index", "Visitor", new {

                    Id = user.Id
                });
            }



            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {

            var checkuser = await _userManager.FindByEmailAsync(model.Email);
            if(checkuser != null)
            {
                return null;
            }

            var newUser = new AppUser
            {
                Name = model.Name,
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.Phone
            };

            var res = await _userManager.CreateAsync(newUser, model.Password);
            if (!res.Succeeded)
            {
                return BadRequest();
            }

            return RedirectToAction("Index","Visitor");
        }



    }
}
