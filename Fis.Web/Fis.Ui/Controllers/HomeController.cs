using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Fis.Ui.Models;
using Fis.Services.Interfaces;
using Fis.Ui.NotificationCenter;
using Microsoft.AspNetCore.SignalR;

namespace Fis.Ui.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMyService _myService;
        private readonly IHubContext<NotifyEnquiry> _hubContext;
        public HomeController(ILogger<HomeController> logger, IMyService myService, IHubContext<NotifyEnquiry> hubContext)
        {
            _logger = logger;
            _myService = myService;
            _hubContext = hubContext;
        }

        public async Task<IActionResult> IndexAsync()
        {
            await _hubContext.Clients.All.SendAsync("NewEnquiryArrived", $"Home page loaded at: {DateTime.Now}","nvnvfd");
            await _myService.Get();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
