using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using QLKho.Models;
using QLKho.ViewModels;

namespace QLKho.Controllers
{
	public class UserController : Controller
	{
		private readonly QlkhoHangContext _context;
		public UserController(QlkhoHangContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{

            return View();
        }
		[HttpGet]
		public async Task<IActionResult> Register()
		{
			var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
			var viewModel = new UserViewModel
			{
				Menus = menus,
			};
			return View(viewModel);
		}
		[HttpGet]
		public async Task<IActionResult> Login()
		{
			var menus = await _context.Menus.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();

			var viewModel = new UserViewModel
			{
				Menus = menus,
			};
			return View(viewModel);
		}
		public async Task<IActionResult> _MenuPartial()
		{
			return PartialView();
		}

	}
}
