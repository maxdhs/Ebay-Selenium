using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Ebay.Models;

namespace Ebay.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            Scraper.myScraper();
            
            return View();
        }
    }
}
