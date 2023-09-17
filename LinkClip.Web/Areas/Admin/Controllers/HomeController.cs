using LinkClip.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LinkClip.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        private readonly ILinkService _linkService;
        public HomeController(ILinkService linkService)
        {
            _linkService = linkService;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Admin";
            return View(await _linkService.GetAllLinks());
        }
    }
}
