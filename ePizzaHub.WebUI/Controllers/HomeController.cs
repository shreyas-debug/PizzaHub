using ePizzaHub.Services.Interfaces;
using ePizzaHub.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace ePizzaHub.WebUI.Controllers
{
    public class HomeController : Controller
    {
        ICatalogService _catalogService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ICatalogService catalogService)
        {
            _logger = logger;
            _catalogService = catalogService;
        }

        public IActionResult Index()
        {
            
            var items = _catalogService.GetItems();
            return View(items);
        }

        //[HttpGet]

        //public async Task<IActionResult> Index(string searchString)
        //{
           
        //    ViewData["Item"] = searchString;

        //    var item = from x in _catalogService.GetItems() select x;
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        item = item.Where(x => x.Name.Contains(searchString));
        //    }
        //    return View(await searchString.ToListAsync());
        //}

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
