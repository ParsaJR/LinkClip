using LinkClip.Application.DTOs.Link;
using LinkClip.Application.Generator;
using LinkClip.Application.Interfaces;
using LinkClip.Domain.Interface;
using LinkClip.Domain.Models.Link;
using LinkClip.Domain.ViewModels.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UAParser;

namespace LinkClip.Application.Services
{
    public class LinkService : ILinkService
    {
        private readonly ILinkRepository _linkRepository;
        public LinkService(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }

        public async Task<UrlRequestResult> AddLink(LinkShortener url)
        {
            if (url == null)
            {
                return UrlRequestResult.Error;
            }

            await _linkRepository.AddLink(url);
            await _linkRepository.SaveChanges();
            return UrlRequestResult.Success;
        }

        public async Task AddRequestUrl(string token)
        {
            var shortUrl = await _linkRepository.FindUrlByToken(token);

            var requestUrl = new RequestUrl
            {
                LinkShortenerId = shortUrl.Id,
                RequestDateTime = DateTime.Now
            };
            requestUrl.CreateDate = DateTime.Now;
            await _linkRepository.AddRequestUrl(requestUrl);
            await _linkRepository.SaveChanges();
        }

        public async Task AddUserAgent(string userAgent)
        {
            var uaparser = Parser.GetDefault();

            ClientInfo client = uaparser.Parse(userAgent);

            var Os = new Domain.Models.Link.OS()
            {
                Family = client.OS.Family,
                Major = client.OS.Major,
                Minor = "No Data",
                CreateDate = DateTime.Now
            };
            await _linkRepository.AddOs(Os);

            var device = new Domain.Models.Link.Device()
            {
                IsBot = client.Device.IsSpider,
                Brand = client.Device.Brand,
                Family = client.Device.Family,
                Model = client.Device.Model,
                CreateDate = DateTime.Now,
            };
            await _linkRepository.AddDevice(device);

            var browser = new Domain.Models.Link.Browser()
            {
                Family = client.UA.Family,
                Major = client.UA.Major,
                Minor = client.UA.Minor,
                CreateDate = DateTime.Now,
            };
            await _linkRepository.AddBrowser(browser);

            await _linkRepository.SaveChanges();
        }

        public async Task<LinkShortener> FindUrlByToken(string token)
        {
            return await _linkRepository.FindUrlByToken(token);
        }

        public async Task<List<AllLinkViewModel>> GetAllLinks()
        {
            return await _linkRepository.GetAllLinks();
        }

        public LinkShortener ShortUrl(Uri uri)
        {
            var shortUrl = new LinkShortener();
            shortUrl.OriginalUrl = uri;
            shortUrl.CreateDate = DateTime.Now;
            shortUrl.Token = Generate.Token();
            shortUrl.Value = new Uri($"https://parsajr.xyz/{shortUrl.Token}"); 
            return shortUrl;
        }
    }
}
