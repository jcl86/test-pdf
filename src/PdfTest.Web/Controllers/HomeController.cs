using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PdfTest.Web.Models;
using Wkhtmltopdf.NetCore;

namespace PdfTest.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGeneratePdf generatePdf;

        public HomeController(ILogger<HomeController> logger, IGeneratePdf generatePdf)
        {
            _logger = logger;
            this.generatePdf = generatePdf;
        }

        public async Task<IActionResult> Index()
        {
            return await generatePdf.GetPdf("Views/Test.cshtml", "Hello World");
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
