using LinkClip.Domain.Interface;
using LinkClip.Domain.Models.Link;
using LinkClip.Domain.ViewModels.Link;
using LinkClip.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkClip.Infrastructure.Data.Repositories
{
    public class LinkRepository : ILinkRepository
    {
        #region constructor
        private readonly LinkClipDbContext _context;
        public LinkRepository(LinkClipDbContext context)
        {
            _context = context;
        }
        #endregion


        public async Task AddLink(LinkShortener url)
        {
            await _context.LinkShorteners.AddAsync(url);
        }

        public async Task AddOs(OS os)
        {
            await _context.OS.AddAsync(os);
        }
        public async Task AddBrowser(Browser browser)
        {
            await _context.Browsers.AddAsync(browser);
        }
        public async Task AddDevice(Device device)
        {
            await _context.Devices.AddAsync(device);
        }

        public async Task<LinkShortener> FindUrlByToken(string token)
        {
            return await _context.LinkShorteners.AsQueryable().SingleOrDefaultAsync(u => u.Token == token);
        }

        public async Task AddRequestUrl(RequestUrl requestUrl)
        {
            await _context.RequestUrls.AddAsync(requestUrl);
        }


        public async Task<List<AllLinkViewModel>> GetAllLinks()
        {
            return await _context.LinkShorteners.AsQueryable()
                .Select(u => new AllLinkViewModel
                {
                    OriginalUrl = u.OriginalUrl.ToString(),
                    Token = u.Token.ToString(),
                    CreateDate = u.CreateDate,
                    Value = u.Value.ToString()
                }).ToListAsync();
        }


        #region dispose & savechange
        public async ValueTask DisposeAsync()
        {
            if (_context != null)
            {
                await _context.DisposeAsync();
            }
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }



        #endregion



    }
}
