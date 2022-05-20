using JSONFileCreate.Models;
using JSONFileCreate.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JSONFileCreate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJsonFileService _jsonService;
        public HomeController(ILogger<HomeController> logger, IJsonFileService jsonService)
        {
            _logger = logger;
            _jsonService = jsonService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string FirstName,string LastName)
        {
            PersonalInformation _objPersonalInfo = new PersonalInformation();
            string strPath = string.Empty;
            if (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName))
            {
                _objPersonalInfo.FName = FirstName;
                _objPersonalInfo.LName = LastName;
                strPath = Path.Combine(Directory.GetCurrentDirectory(), "PersonalInfo.json");
                _jsonService.CreateJSONFile(strPath, _objPersonalInfo);
            }
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
