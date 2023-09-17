using LinkClip.Domain.Models.Link;
using LinkClip.Domain.ViewModels.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkClip.Domain.Interface
{
    public interface ILinkRepository : IAsyncDisposable
    {
        Task AddLink(LinkShortener url);
        Task AddOs(OS os);

        Task AddDevice(Device device);

        Task AddBrowser(Browser browser);

        Task<LinkShortener> FindUrlByToken(string token);

        Task AddRequestUrl(RequestUrl requestUrl);

        Task<List<AllLinkViewModel>> GetAllLinks();

        Task SaveChanges();
    }
}
