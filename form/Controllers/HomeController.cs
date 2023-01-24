using form.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System;
using System.Diagnostics;
using Xunit.Sdk;

namespace form.Controllers
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
		[HttpPost]
        public IActionResult Index(Form request)
		{
			//if(request == null)
			//{
			//	return View();
			//}

            if (ModelState.IsValid)
			{
                
                return RedirectToAction("Index");

            }
			return View(request);
        }

        public IActionResult Privacy()
		{
			return View();
		}

        public IActionResult Vista()
        {
            return View("Vista");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}