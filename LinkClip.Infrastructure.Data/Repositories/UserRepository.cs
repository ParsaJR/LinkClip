using LinkClip.Domain.Interface;
using LinkClip.Domain.Models.Account;
using LinkClip.Domain.ViewModels.Account;
using LinkClip.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LinkClip.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LinkClipDbContext _context;
        public UserRepository(LinkClipDbContext context)
        {
            _context = context;
        }
        #region account
        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);

        }
        public async Task<bool> IsMobileExist(string mobile)
        {
            return await _context.Users.AnyAsync(u => u.Mobile == mobile);
        }

        public async Task<User> GetUserByPhoneNumber(string phoneNumber)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Mobile == phoneNumber);
        }

        public async Task<List<UserForShowViewModel>> GetAllUsersForShow()
        {
            var allUser = await _context.Users.AsQueryable().Select(u => new UserForShowViewModel
            {
                UserId = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Mobile = u.Mobile,
                IsAdmin = u.IsAdmin,
                IsBlocked = u.IsBlocked
            }).ToListAsync();
            return allUser;
        }
        public async Task<User> GetUserById(long userId)
        {
            return await _context.Users.AsQueryable()
                .SingleOrDefaultAsync(u => u.Id == userId);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }

        #endregion

        #region dispose & save change
        public async ValueTask DisposeAsync()
        {
            if (_context != null)
            {
                await _context.DisposeAsync();
            }
        }

      

        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }

      





        #endregion

    }
}
