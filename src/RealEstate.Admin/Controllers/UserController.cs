using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using src.RealEstate.Admin.Models.User;
using src.RealEstate.Common.Constants;
using src.RealEstate.Common.Enum;
using src.RealEstate.Common.Functions;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<EstateUser> _userManager;
        private readonly SignInManager<EstateUser> _signInManager;

        public UserController(UserManager<EstateUser> userManager, SignInManager<EstateUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> CreateUser()
        {
            var user = new EstateUser
            {
                Id = Guid.NewGuid(),
                UserName = "admin",
                Email = "erenkaya2580@gmail.com",
                PhoneNumber = "123456789",
            };

            try
            {
                await _userManager.CreateAsync(user, "admin123");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        [HttpGet("/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(UserLoginViewModel model)
        {
            EstateUser user;
            var loginProvider = Utility.GetLoginProvider(model.Username);

            if (loginProvider == LoginProvider.Email)
                user = await _userManager.FindByEmailAsync(model.Username);
            else
                user = await _userManager.FindByNameAsync(model.Username);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.IsPersistent, false);
                if (result.Succeeded)
                    return RedirectToAction("index", "home");
            }

            ViewData["LoginError"] = Messages.LOGIN_ERROR;
            return View(model);
        }
    }
}