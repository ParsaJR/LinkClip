using LinkClip.Application.DTOs.Account;
using LinkClip.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LinkClip.Web.Areas.Admin.Controllers
{
    public class AccountController : AdminBaseController
    {
        #region constructor
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        [HttpGet("user-manage")]
        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetAllUsersForShow());
        }

        #region edit user

        [HttpGet("edit-user/{userId}")]
        public async Task<IActionResult> EditUser(long userId)
        {
            return View(await _userService.GetEditUserByAdmin(userId));
        }
        [HttpPost("edit-user/{userId}")]
        public async Task<IActionResult> EditUser(EditUserDTO editUser)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.EditUser(editUser);
                switch (result)
                {
                    case EditUserResult.NotFound:
                        TempData[ErrorMessage] = "User NotFound";
                        break;
                    case EditUserResult.Success:
                        TempData[SuccessMessage] = "User edited successfully";
                        return RedirectToAction("Index");
                }





            }
            return View();
        }
        #endregion

        #region create user in admin
        [HttpGet("create-user")]
        public async Task<IActionResult> CreateUser()
        {
            return View();
        }
        [HttpPost("create-user"), ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(CreateUserDTO createUser)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.AddUserByAdmin(createUser);
                switch (result)
                {
                    case CreateUserResult.IsMobileExist:
                        TempData[ErrorMessage] = "Mobile Is Exist";
                        break;
                    case CreateUserResult.Success:
                        TempData[SuccessMessage] = "User Added Successfully";
                        return RedirectToAction("Index");
                }
            }
            return View(createUser);
        }

        #endregion

    }
}
