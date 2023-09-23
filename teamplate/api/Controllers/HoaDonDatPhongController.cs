using api.Models.RequestModels;
using api.Models.ResponseModels;
using api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonDatPhongController : ControllerBase
    {
        private readonly IHoaDonDatHangService _hoaDonDatHangService;
        private readonly IMapper _mapper;
        public HoaDonDatPhongController(IHoaDonDatHangService hoaDonDatHangService, IMapper mapper)
        {
            _hoaDonDatHangService = hoaDonDatHangService;
            _mapper = mapper;
        }
        [HttpGet("hoaDonDatPhong")]
        public async Task<IActionResult> GetHoaDons()
        {
            var hoaDon = await _hoaDonDatHangService.GetHoaDons();
            return Ok(_mapper.Map<List<HoaDonDatPhongResponse>>(hoaDon));
        }
        [HttpGet("hoaDonDatPhong/{id}")]
        public async Task<IActionResult> GetHoaDonId(int id)
        {
            var hoaDon = await _hoaDonDatHangService.GetHoaDon(id);
            return Ok(_mapper.Map<HoaDonDatPhongResponse>(hoaDon));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HoaDonDatPhongRequest hoaDon)
        {
            await _hoaDonDatHangService.CreateHoaDon(hoaDon);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, HoaDonDatPhongResponse hoaDonDatPhongResponse)
        {
            await _hoaDonDatHangService.UpdateHoaDon(id, hoaDonDatPhongResponse);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _hoaDonDatHangService.DeleteHoaDon(id);
            return Ok();
        }
    }
}
