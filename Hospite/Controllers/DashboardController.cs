using Hospite.Data;
using Hospite.Data.Repository;
using Hospite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospite.Controllers
{
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMailService _mailService;

        public DashboardController(UserManager<AppUser> userManager,IScheduleRepository scheduleRepository, IMailService mailService)
        {
            _userManager = userManager;
            _scheduleRepository = scheduleRepository;
            _mailService = mailService;
        }

        public async Task<IActionResult> Index(string? msg)
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

            var num = _scheduleRepository.Notification();

            var res = new UserViewModel
            {
                Name = user.Name,
                Phone = user.PhoneNumber,
                Email = user.Email,
                GetSchedules = user.Schedules,
                Notification = num

            };

            ViewBag.Message = msg;
            return View(res);
        }

        [HttpGet]
        public async Task<IActionResult> Admin()
        {
            var id = HttpContext.Session.GetString("Id");
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Login", "Account");
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
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
        public IActionResult Edit([FromForm] UserViewModel model)
        {
            return RedirectToAction("Profile");
        }



        [HttpGet]
        public IActionResult BookEmployee()
        {
           
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> BookEmployee([FromForm] RegisterVisitorViewModel model)
        {
            var Password = "Password@2021";
            var userSchedule = new Schedule();
            var ListOfSchedule = new List<Schedule>();
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Ops! An error occured";
                return View(model);
            }

            var tag = await _scheduleRepository.TagExist(model.TagNo);

            if(tag == true)
            {

                ViewBag.Message = "Tag Already exist!";
                return View(model);
            }
            var checkUser =await _userManager.FindByEmailAsync(model.Email);


            //mapping here
            var userAddress = new Address
            {
                AddressTitle = model.Address.AddressTitle,
                City = model.Address.City,
                StreetNo = model.Address.StreetNo,
            };

            userSchedule = new Schedule
            {
                Purpose = model.Purpose,
                FromWhere = model.FromWhere,
                ToWhom = model.ToWhom,
                Tag = model.TagNo,
                TimeIn = DateTime.Now

            };

            ListOfSchedule.Add(userSchedule);
            var newUser = new AppUser
            {
                Name = model.Name,
                Gender = model.Gender,
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = userAddress,
                Schedules = ListOfSchedule

            };

            if (checkUser == null)
            {
                var res = await _userManager.CreateAsync(newUser, Password);
                if (!res.Succeeded)
                {
                    ViewBag.Message = "User not Created!";
                    return BadRequest();
                }

            }
            else
            {
                userSchedule = new Schedule
                {
                    AppUserId = checkUser.Id,
                    Purpose = model.Purpose,
                    FromWhere = model.FromWhere,
                    ToWhom = model.ToWhom,
                    Tag = model.TagNo,
                    TimeIn = DateTime.Now

                };

                var sch =await _scheduleRepository.CreateSchedule(userSchedule);
                if (!sch)
                {
                    ViewBag.Message = "Schedule not Created!";
                    return BadRequest();
                }


            }

            ViewBag.Message = "Schedule Created!";
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> SignOutVisitor([FromForm] string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                ViewBag.Message = "An error Occured";
                return BadRequest();
            }

            var res =await _scheduleRepository.GetScheduleByTagNumber(search);
            if(res == null)
            {
              
                return RedirectToAction("Index", new { msg = "Schedule Does Not Exist"
                     });
            }
            var user = await _userManager.Users.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == res.AppUserId);
            var myRes = new SignOutViewModel
            {
                PhoneNumber = user.PhoneNumber,
                TagNo = res.Tag,
                GrantedAccess = res.IsGranted,
                BookingTime = res.BookingTime,
                VisitorName = user.Name,
                Address = user.Address,
                FromWhere = res.FromWhere,
                Purpose = res.Purpose,
                ToWhom = res.ToWhom,
                Gender = user.Gender,
                TimeIn = res.TimeIn,
                TimeOut = res.TimeOut,
                Email = user.Email,
                UserId = user.Id,
                Cancelled = res.Cancelled
            };


            return View("ViewVisitors", myRes);

        }


        [HttpGet]
        public async Task<IActionResult> Access()
        {
            var content = new List<ScheduledUserViewModel>();

           var listOfSchedule = await _scheduleRepository.GetAllSchedule();
            foreach (var item in listOfSchedule)
            {

                var visitors = new ScheduledUserViewModel
                {
                    IsGranted = item.IsGranted,
                    BookingTime = item.BookingTime,
                    Contact = item.AppUser.PhoneNumber,
                    Name = item.AppUser.Name,
                    UserId = item.AppUserId,
                    TagNo = item.Tag,
                    Cancelled = item.Cancelled
                };
                content.Add(visitors);
            }

            return View("Access", content);
        }

        [HttpGet]
        public async Task<IActionResult> ViewDetails(string id, string tag)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(tag)) return View("Access");

            var res = await _scheduleRepository.GetScheduleByTagNumber(tag);
            if (res == null)
            {
                ViewBag.Message = "Schedule Does Not Exist";
                return RedirectToAction("Access");
            }        
            var user = await _userManager.Users.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);
       

            var myRes = new SignOutViewModel
            {
                PhoneNumber = user.PhoneNumber,
                TagNo = res.Tag,
                GrantedAccess = res.IsGranted,
                BookingTime = res.BookingTime,
                VisitorName = user.Name,
                Address = user.Address,
                FromWhere = res.FromWhere,
                Purpose = res.Purpose,
                ToWhom = res.ToWhom,
                Gender = user.Gender,
                TimeIn = res.TimeIn,
                TimeOut = res.TimeOut,
                Email = user.Email,
                UserId = user.Id,
                Cancelled = res.Cancelled
               

            };

            return View("ViewVisitors", myRes);
         
        }

        [HttpGet]
        public async Task<IActionResult> GrantAccess(string tag)
        {
            

            if (string.IsNullOrEmpty(tag))
            {
                ViewBag.Message = "Invalid tag";
                return View("Access");
            }

            var res =await _scheduleRepository.GetScheduleByTagNumber(tag);
            if (res == null)
            {
                ViewBag.Message = "Schedule Does Not Exist";
                return RedirectToAction("Access");

            }
            var user = await _userManager.FindByIdAsync(res.AppUserId);
            res.TimeIn = DateTime.Now;
            res.IsGranted = true;

            var update = await _scheduleRepository.UpdateSchedule(res);
            if (!update)
            {
                ViewBag.Message = "Update failed";
                return RedirectToAction("Access");
            }

            //trigger a send mail here
            var response = await SendMailAsync(user.Name, "Access Granted", "You have been Granted Access to see the requested Employee", user.Email);
            

            //
            return RedirectToAction("Access");



        }

        [HttpGet]
        public async Task<IActionResult> SignVisitorOut(string Id, string Tag)
        {
            if (string.IsNullOrEmpty(Tag))
            {

                return View("Access");
            }

            var res = await _scheduleRepository.GetScheduleByTagNumber(Tag);
            if (res == null)
            {
                ViewBag.Message = "Schedule Does Not Exist";
                return RedirectToAction("Access");
            }
            var user = await _userManager.FindByIdAsync(res.AppUserId);

            res.TimeOut = DateTime.Now;
            res.IsGranted = false;
            res.Cancelled = true;

            var update = await _scheduleRepository.UpdateSchedule(res);

            if (update == false)
            {
                ViewBag.Message = "Update falied";
                return RedirectToAction("Access");
            }

            //trigger a send mail here
            var response = await SendMailAsync(user.Name, "Signed Out", $"Thank you {user.Name} for visiting",user.Email);
           
            //
            return RedirectToAction("ViewDetails", new { 
                id = Id,
                tag = Tag
            });
        }


        [HttpGet]
        public async Task<IActionResult> CancelBooking(string tag)
        {
            if (string.IsNullOrEmpty(tag))
            {
                return View("Access");
            }

            var res = await _scheduleRepository.GetScheduleByTagNumber(tag);
            if (res == null)
            {
                ViewBag.Message = "Schedule Does Not Exist";
                return RedirectToAction("Access");
            }
            var user = await _userManager.FindByIdAsync(res.AppUserId);
            res.Cancelled = true;
            res.TimeOut = DateTime.Now;

            var update = await _scheduleRepository.UpdateSchedule(res);

            if (update == false)
            {
                ViewBag.Message = "Update falied";
                return RedirectToAction("Access");
            }
            //trigger a send mail here
            var response = await SendMailAsync(user.Name, "Appointment Canceled", $"Sorry,{user.Name}. The requested Employee is not available today. Try some Other Time..Thank you for visiting.", user.Email);
           

            //
            return RedirectToAction("Access");
        }


        private async Task<bool> SendMailAsync (string name,string subject,string body,string recieptMail)
        {
            try
            {
                var mailRequest = new MailRequest
                {
                    Name = name,
                    Subject = subject,
                    Body = body,
                    RecipientMail = recieptMail
                };

                await _mailService.SendMailAsync(mailRequest);

            }
            catch(Exception ex)
            {

            }
            

            return true;
        }

    }
}
