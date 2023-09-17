using LinkClip.Application.DTOs.Link;
using LinkClip.Domain.Models.Link;
using LinkClip.Domain.ViewModels.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkClip.Application.Interfaces
{
    public interface ILinkService
    {
        LinkShortener ShortUrl(Uri uri);
        Task<UrlRequestResult> AddLink(LinkShortener url);

        Task AddUserAgent(string userAgent);

        Task<LinkShortener> FindUrlByToken(string token);

        Task<List<AllLinkViewModel>> GetAllLinks();

        Task AddRequestUrl(string token);

    }
}
