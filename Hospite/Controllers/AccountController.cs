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
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
                
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
                ViewBag.LoginErrMsg = true;
                return View();
            }
            var checkPassword = await _signInManager.PasswordSignInAsync(user,model.Password,false,false);
            if (!checkPassword.Succeeded)
            {
                return View();
            }

            var role = await _userManager.GetRolesAsync(user);

            HttpContext.Session.SetString("Id",user.Id);
            HttpContext.Session.SetString("Role",role[0]);


            if (role.Contains("Admin"))
            {
                return RedirectToAction("Index", "Dashboard", new
                {
                    Id = user.Id
                }
                );
            }


            if (role.Contains("Employee"))
            {
                return RedirectToAction("Index", "Dashboard", new
                {

                    Id = user.Id
                });
            }



            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterViewModel model)
        {
            var DefaultPassword = "Password@2021";
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

            var res = await _userManager.CreateAsync(newUser, DefaultPassword);
            var role = await _userManager.AddToRoleAsync(newUser,"Employee");
            if (!res.Succeeded)
            {
                return BadRequest();
            }

            ViewBag.Message = "User Created";
            return RedirectToAction("Index","Dashboard");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }


    }
}
