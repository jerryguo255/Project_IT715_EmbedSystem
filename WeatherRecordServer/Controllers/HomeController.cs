using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WeatherRecordServer.Models;

namespace WeatherRecordServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WeatherRecordDBContext _context;

        public HomeController(ILogger<HomeController> logger, WeatherRecordDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(int? num)
        {
            HomeViewModel hvm = null;
            if (num != null)
            { hvm = new HomeViewModel(num.Value); }
            else
            { hvm = new HomeViewModel(7); }//7 days ago data


            var list = await _context.WeatherRecords.ToListAsync();
            for (int i = 0; i < hvm.days.Length; i++)
            {
                var Dailylists = list.Where(x => x.DateCollection.DayOfYear == hvm.days[i].DayOfYear).ToList();
                if (Dailylists.Count != 0)
                {
                    hvm.daysAvgInDoorHum[i] =
                     Dailylists.ToList().Average(x => x.HumIndoor);
                    hvm.daysAvgInDoorTemp[i] =
                            Dailylists.ToList().Average(x => x.TempIndoor);

                    hvm.daysAvgOutSideHum[i] =
                           Dailylists.ToList().Average(x => x.HumOutside);
                    hvm.daysAvgOutSideTemp[i] =
                            Dailylists.ToList().Average(x => x.TempOutside);
                }

            }
            return View(hvm);
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
