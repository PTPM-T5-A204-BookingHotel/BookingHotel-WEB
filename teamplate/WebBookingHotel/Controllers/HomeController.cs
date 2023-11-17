using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using WebBookingHotel.Models;

namespace WebBookingHotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        string baseURL = "https://localhost:7146/api/DatPhong/";
        private readonly HttpClient _client;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseURL);
        }
        public IActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> Index(DatPhongViewModel model)
		{
			try
			{
				HttpResponseMessage responseMessage = await _client.GetAsync(_client.BaseAddress + $"Check/{model.Sdt}");

				if (!responseMessage.IsSuccessStatusCode)
				{
					ModelState.AddModelError("Sdt", "The phone number already exists in the system.");
					return View(model);
				}
				TempData["SDT"] = model.Sdt;
				if (ModelState.IsValid)
				{
					string data = JsonConvert.SerializeObject(model);
					StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
					responseMessage = await _client.PostAsync(_client.BaseAddress + "Post", content);

					if (responseMessage.IsSuccessStatusCode)
					{
						return RedirectToAction("UploadImage");
					}
				}
				else
				{
					return View(model);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred.");
				return BadRequest("An error occurred.");
			}

			return View();
		}

		public IActionResult UploadImage()
        {
			string sdt = TempData["SDT"]?.ToString();
			var model = new DatPhongImageViewModel
			{
				Sdt = sdt
			};
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> UploadImage(DatPhongImageViewModel model)
		{
			try
			{
				if (model.HinhAnh != null && model.HinhAnh.Length > 0)
				{
					using (var content = new MultipartFormDataContent())
					{
						content.Add(new StringContent(model.Sdt.ToString()), "Sdt");

						content.Add(new StreamContent(model.HinhAnh.OpenReadStream())
						{
							Headers =
					{
						ContentLength = model.HinhAnh.Length,
						ContentType = new MediaTypeHeaderValue(model.HinhAnh.ContentType)
					}
						}, "HinhAnh", model.HinhAnh.FileName);

						HttpResponseMessage responseMessage = await _client.PostAsync(baseURL + "UploadImage", content);

						if (responseMessage.IsSuccessStatusCode)
						{
							return RedirectToAction("Cheers");
						}
					}
				}
				else
				{
					ModelState.AddModelError("HinhAnh", "Please select an image file.");
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred.");
				return BadRequest("An error occurred.");
			}
			return View(model);
		}
		public IActionResult Cheers()
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