using LinkClip.Application.DTOs.Link;
using LinkClip.Application.Interfaces;
using LinkClip.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LinkClip.Web.Controllers
{
    public class HomeController : SiteBaseController
    {
        #region constructor
        private readonly ILinkService _linkService;
        public HomeController(ILinkService linkService)
        {
            _linkService = linkService;
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(UrlRequestDTO urlRequest)
        {
            if (ModelState.IsValid)
            {
                if (!User.Identity.IsAuthenticated)
                {
                    TempData[WarningMessage] = "You Must Login";
                    return View(urlRequest);
                }
                if (urlRequest.OriginalUrl.Contains("https://") || urlRequest.OriginalUrl.Contains("http://"))
                {
                    var url = new Uri(urlRequest.OriginalUrl);
                    var shortUrl = _linkService.ShortUrl(url);

                    var result = await _linkService.AddLink(shortUrl);
                    switch (result)
                    {
                        case UrlRequestResult.Success:
                            TempData[SuccessMessage] = "Success";
                            ViewBag.IsSuccess = true;
                            ViewBag.UserShortLink = shortUrl.Value.ToString();
                            break;
                        case UrlRequestResult.Error:
                            TempData[ErrorMessage] = "Error";
                            break;

                    }
                }
                else
                {
                    TempData[InfoMessage] = "The link must start with https";
                    return View(urlRequest);
                }
            }
            return View(urlRequest);
        }
    }
}