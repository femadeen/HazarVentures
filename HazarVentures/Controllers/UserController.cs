using HazarVentures.Interfaces.Services;
using HazarVentures.ViewModels.RequestModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace HazarVentures.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult UserInfo()
        {
            int id = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = _userService.GetUserById(id);
            return View(user);
        }


        [HttpPost]
        public IActionResult Login(LoginRequestModel model)
        {
            var loginStatus = _userService.Login(model);
            if(loginStatus.Status == false)
            {
                ViewBag.Message = loginStatus.Message;
                return View();
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, loginStatus.Data.Id.ToString()),
                new Claim(ClaimTypes.Email, loginStatus.Data.Email),
                new Claim(ClaimTypes.Role, loginStatus.Data.RoleName)
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authenticationProperties = new AuthenticationProperties();
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);
            if(loginStatus.Data.RoleName.ToLower() == "student")
            {
                return RedirectToAction("UserInfo");
            }
            else
            {
                return RedirectToAction("UserInfo");
            }
            
        }
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
