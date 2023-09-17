using LinkClip.Application.DTOs.Account;
using LinkClip.Application.Interfaces;
using LinkClip.Domain.Interface;
using LinkClip.Domain.Models.Account;
using LinkClip.Domain.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkClip.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMD5PasswordHelper _passwordHelper;

        public UserService(IUserRepository userRepository, IMD5PasswordHelper passwordHelper)
        {
            _userRepository = userRepository;
            _passwordHelper = passwordHelper;
        }




        #region account
        public async Task<RegisterUserResult> RegisterUser(RegisterUserDTO registerUser)
        {
            if (!await _userRepository.IsMobileExist(registerUser.Mobile))
            {
                var user = new User
                {
                    FirstName = registerUser.FirstName,
                    LastName = registerUser.LastName,
                    Mobile = registerUser.Mobile,
                    IsMobileActive = true,
                    CreateDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    Password = _passwordHelper.EncodePasswordMd5(registerUser.Password),
                    IsAdmin = false
                };
                await _userRepository.AddUser(user);
                await _userRepository.SaveChange();
                return RegisterUserResult.Success;


            }
            else
            {
                return RegisterUserResult.IsMobileExist;
            }
        }

        public async Task<loginUserResult> LoginUser(LoginUserDTO loginUser)
        {
            var user = await _userRepository.GetUserByPhoneNumber(loginUser.Mobile);
            if (user == null)
            {
                return loginUserResult.NotFound;
            }
            if (!user.IsMobileActive)
            {
                return loginUserResult.NotActived;
            }
            if (user.Password != _passwordHelper.EncodePasswordMd5(loginUser.Password))
            {
                return loginUserResult.NotFound;
            }
            return loginUserResult.Success;
        }

        public async Task<User> GetUserByPhoneNumber(string phoneNumber)
        {
            return await _userRepository.GetUserByPhoneNumber(phoneNumber);
        }

        public async Task<List<UserForShowViewModel>> GetAllUsersForShow()
        {
            return await _userRepository.GetAllUsersForShow();
        }

        public async Task<EditUserResult> EditUser(EditUserDTO editUser)
        {
            var user = await _userRepository.GetUserById(editUser.UserId);
            if (user == null)
            {
                return EditUserResult.NotFound;
            }
            user.FirstName = editUser.FirstName;
            user.LastName = editUser.LastName;
            user.IsAdmin = editUser.IsAdmin;
            user.IsBlocked = editUser.IsBlocked;
            _userRepository.UpdateUser(user);
            await _userRepository.SaveChange();
            return EditUserResult.Success;
        }

        public async Task<EditUserDTO> GetEditUserByAdmin(long userId)
        {
            var user = await _userRepository.GetUserById(userId);

            return new EditUserDTO
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsAdmin = user.IsAdmin,
                IsBlocked = user.IsBlocked,
                Mobile = user.Mobile,
            };
        }

        public async Task<CreateUserResult> AddUserByAdmin(CreateUserDTO createUser)
        {
            if (!await _userRepository.IsMobileExist(createUser.Mobile))
            {
                var user = new User
                {
                    FirstName = createUser.FirstName,
                    LastName = createUser.LastName,
                    Mobile = createUser.Mobile,
                    IsMobileActive = true,
                    CreateDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                    Password = _passwordHelper.EncodePasswordMd5(createUser.Password),
                    IsAdmin = createUser.IsAdmin
                };
                await _userRepository.AddUser(user);
                await _userRepository.SaveChange();
                return CreateUserResult.Success;


            }
            else
            {
                return CreateUserResult.IsMobileExist;
            }
        }

        #endregion
    }
}
