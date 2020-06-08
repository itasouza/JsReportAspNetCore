using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JsReportAspNetCore.Models;
using jsreport.AspNetCore;
using jsreport.Types;

namespace JsReportAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 1 -  fazer a instalação do  jsreport.AspNetCore; jsreport.Binary, jsreport.Local
        /// 2 -  adicionar a configuração do Startup
        /// </summary>
        /// <returns></returns>


        [MiddlewareFilter(typeof(JsReportPipeline))]
        public IActionResult JSReportPDF()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                Name = "Itamar",
                LastName = "Souza"
            };

            HttpContext.JsReportFeature().Recipe(Recipe.ChromePdf);
            return View(person);
        }




        public IActionResult Index()
        {
          
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
