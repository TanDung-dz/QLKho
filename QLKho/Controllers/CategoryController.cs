using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QLKho.ViewModels;
using static System.Net.WebRequestMethods;

namespace QLKho.Controllers
{
	public class CategoryController : Controller
	{
		Uri baseAddress = new Uri("https://localhost:44334/api");
		private readonly HttpClient _client;

		public CategoryController()
			{
			_client = new HttpClient();
			_client.BaseAddress = baseAddress;
			}

		[HttpGet]
		public IActionResult Index()
		{
			List<CategoryViewModel> categories = new List<CategoryViewModel>();
			HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/category/Get").Result;

			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				categories = JsonConvert.DeserializeObject<List<CategoryViewModel>>(data);
			}
			return View();
		}
	}
}
