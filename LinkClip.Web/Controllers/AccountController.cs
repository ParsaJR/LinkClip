using LinkClip.Application.DTOs.Account;
using LinkClip.Application.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LinkClip.Web.Controllers
{
    public class AccountController : SiteBaseController
    {
        #region constructor
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion
        #region register
        [HttpGet("register")]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost("register"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserDTO registerUser)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUser(registerUser);
                switch (result)
                {
                    case RegisterUserResult.IsMobileExist:
                        TempData[ErrorMessage] = "Phone Number is Exist";
                        ModelState.AddModelError("Phone", "Phone Number is Exist");
                        break;
                    case RegisterUserResult.Success:
                        TempData[SuccessMessage] = "Register Successful";
                        return Redirect("/");


                }
            }
            return View(registerUser);
        }
        #endregion

        #region login
        [HttpGet("login")]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost("login"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserDTO loginUser)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUser(loginUser);
                switch (result)
                {
                    case loginUserResult.NotFound:
                        TempData[ErrorMessage] = "User Not Found";
                        break;
                    case loginUserResult.NotActived:
                        TempData[WarningMessage] = "User Not Actived";
                        break;
                    case loginUserResult.Success:
                        var user = await _userService.GetUserByPhoneNumber(loginUser.Mobile);
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,user.Mobile),
                            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                            new Claim("IsAdmin",user.IsAdmin.ToString())
                        };
                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principle = new ClaimsPrincipal(identity);
                        var properties = new AuthenticationProperties
                        {
                            IsPersistent = loginUser.RememberMe

                        };
                        await HttpContext.SignInAsync(principle, properties);
                        TempData[SuccessMessage] = "Welcome";
                        return Redirect("/");
                }
            }
            return View(loginUser);
        }
        #endregion

        #region logout
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            TempData[SuccessMessage] = "Logged Out";
            return Redirect("/");
        }
        #endregion

    }
}
