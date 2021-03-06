using AzureAdOpenIDConnectToBlobStorage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AzureAdOpenIDConnectToBlobStorage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult AuthoAction()
        {
            ViewBag.Activiteit = "Autho is clicked.";
            
            return View("Index");
        }

        [AllowAnonymous]
        public IActionResult AnoAction()
        {
            ViewBag.Activiteit = "Currently is Ano clicked.";
            return View("Index");
        }

        public IActionResult UndecoratedAction()
        {
            ViewBag.Activiteit = "The Undecorated is clicked.";
            return View("Index");
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
