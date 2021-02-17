using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using src.RealEstate.Admin.Models.User;
using src.RealEstate.Common.Constants;
using src.RealEstate.Common.Enum;
using src.RealEstate.Common.Functions;
using src.RealEstate.Entity.DTOs;
using src.RealEstate.Entity.Entities;
using src.RealEstate.Service.Contracts;

namespace src.RealEstate.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<EstateUser> _userManager;
        private readonly SignInManager<EstateUser> _signInManager;
        private readonly IMailService _mailService;

        public UserController(UserManager<EstateUser> userManager, SignInManager<EstateUser> signInManager, IMailService mailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mailService = mailService;
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
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

        [HttpGet("/ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost("/ForgotPassword")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(UserForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var httpEncodedToken = HttpUtility.UrlEncode(resetToken);
                var content = $"<p>Parolanızı sıfırlamak için <a href=\"https://localhost:5001{Url.Action("ResetPassword", "User", new { userId = user.Id, token = httpEncodedToken })}\">tıklayınız</a>.</p>" +
                                "<p>Bu link 10 dakika sonra geçersiz olacaktır.</p>";

                var mailDto = new MailDTO
                {
                    From = _mailService.Username,
                    Subject = "Reset Password",
                    To = new List<string> { model.Email },
                    Content = content
                };

                await _mailService.Send(mailDto);
            }

            ViewData["ForgotPasswordMessage"] = Messages.FORGOT_PASSWORD_MESSAGE;
            return View(model);
        }
    }
}