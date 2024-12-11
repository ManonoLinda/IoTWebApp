using System.Diagnostics;
using DigitalMatterWebApp.Data;
using DigitalMatterWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalMatterWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
          var deviceFirmwareData = await _context.Devices
                .Include(d => d.Firmware)
                .Select(d => new DeviceFirmwareViewModel
                {
                    DeviceID = d.DeviceID,
                    DeviceName = d.DeviceName,
                    FirmwareID = d.Firmware.FirmwareID,
                    FirmwareVersion = d.Firmware.Version,
                    ReleaseDate = d.Firmware.ReleaseDate
                })
                .ToListAsync();
            return View(deviceFirmwareData);
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
