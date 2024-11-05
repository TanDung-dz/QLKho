using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLKho.Models;
using QLKho.ViewModels;
using System.Diagnostics;

namespace QLKho.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QlkhoHangContext _context;
        public HomeController(ILogger<HomeController> logger, QlkhoHangContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var slides = await _context.Sliders.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();

            var viewModel = new HomeViewModel
            {
                Menus = menus,
                Sliders = slides,
            };
            return View(viewModel);
        }

        public IActionResult Service()
        {
            return View();
        }
        public async Task<IActionResult> _SlidePartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> _MenuPartial()
        {
            return PartialView();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
