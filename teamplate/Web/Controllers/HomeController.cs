using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using Web.Models;

namespace Web.Controllers
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
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public Task<IActionResult> Index(DatPhongViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = _client.PostAsync(_client.BaseAddress + "Post", content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                   
                }
            }
            catch (Exception)
            {
                return Task.FromResult<IActionResult>(View());
                throw;
            }
            return Task.FromResult<IActionResult>(View());
        }
        [HttpGet]
        public IActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(DatPhongImageViewModel model)
        {
            try
            {
                using (var content = new MultipartFormDataContent())
                {
                    content.Add(new StringContent(model.MaDp.ToString()), "MaDp");

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
                        
                    }
                }
            }
            catch (Exception)
            {
                
            }
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