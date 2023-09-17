using LinkClip.Domain.Models.Account;
using LinkClip.Domain.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkClip.Domain.Interface
{
    public interface IUserRepository : IAsyncDisposable
    {
        Task AddUser(User user);

        Task<User> GetUserByPhoneNumber(string phoneNumber);
        Task<bool> IsMobileExist(string mobile);

        Task<List<UserForShowViewModel>> GetAllUsersForShow();
        Task<User> GetUserById(long userId);
        void UpdateUser(User user);
        
        Task SaveChange();
    }
}
