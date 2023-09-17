
using LinkClip.Application.DTOs.Account;
using LinkClip.Domain.Models.Account;
using LinkClip.Domain.ViewModels.Account;
using System.Threading.Tasks;

namespace LinkClip.Application.Interfaces
{
    public interface IUserService
    {
        Task<RegisterUserResult> RegisterUser(RegisterUserDTO registerUser);
        Task<loginUserResult> LoginUser(LoginUserDTO loginUser);

        Task<User> GetUserByPhoneNumber(string phoneNumber);

        Task<List<UserForShowViewModel>> GetAllUsersForShow();

        Task<EditUserResult> EditUser(EditUserDTO editUser);
        Task<EditUserDTO> GetEditUserByAdmin(long userId);

        Task<CreateUserResult> AddUserByAdmin(CreateUserDTO createUser);

    }
}
