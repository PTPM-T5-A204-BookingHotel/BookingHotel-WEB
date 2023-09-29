using bookinghotel_web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace bookinghotel_web.Controllers
{
    public class HoaDonDatPhongController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5220/api");
        private readonly HttpClient _httpClient;
        public HoaDonDatPhongController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<HoaDonDatPhongViewModel> list = new List<HoaDonDatPhongViewModel>();
            HttpResponseMessage respone = _httpClient.GetAsync(_httpClient.BaseAddress + "/HoaDonDatPhong/Get").Result;
            if(respone.IsSuccessStatusCode) {
                string data = respone.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<HoaDonDatPhongViewModel>>(data);
            }
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HoaDonDatPhongViewModel vm)
        {
            try
            {
                string data = JsonConvert.SerializeObject(vm);
                StringContent content = new StringContent(data,Encoding.UTF8,"application/json");
                HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "/HoaDonDatPhong/Post",content).Result;
                if(response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Success!!!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                HoaDonDatPhongViewModel vm = new HoaDonDatPhongViewModel();
                HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/HoaDonDatPhong/GetHoaDonId" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    vm = JsonConvert.DeserializeObject<HoaDonDatPhongViewModel>(data);
                }
                return View(vm);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
        [HttpPost]
        public IActionResult Edit(int id,HoaDonDatPhongViewModel vm)
        {
            try
            {
                string data = JsonConvert.SerializeObject(vm);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PutAsync(_httpClient.BaseAddress + "/HoaDonDatPhong/Put" + vm.Id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Success!!!";
                    return RedirectToAction("Index");
                }
            }
            catch ( Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }
    }
}
