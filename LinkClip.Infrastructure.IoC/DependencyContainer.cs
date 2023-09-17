using LinkClip.Application.Interfaces;
using LinkClip.Application.Services;
using LinkClip.Domain.Interface;
using LinkClip.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkClip.Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services)
        {
            #region repository
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILinkRepository, LinkRepository>();
            #endregion
            #region services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILinkService, LinkService>();
            #endregion
            #region tools
            services.AddScoped<IMD5PasswordHelper, MD5PasswordHelper>();
            #endregion
        }
    }
}
