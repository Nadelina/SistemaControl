using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaControl.Models;

namespace SistemaControl.Controllers
{
    public class HomeController : Controller
    {
        private readonly NegociosLlamadasContext _context;
        public HomeController(NegociosLlamadasContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
             var ultimas = _context.Llamadas.OrderByDescending(x=>x.FechaHora).Take(4).ToList();


            return View(ultimas);
        }       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
