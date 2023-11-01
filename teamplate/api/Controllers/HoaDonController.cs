using api.Models.RequestModels;
using api.Models.ResponseModels;
using api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private readonly IHoaDonService _hoaDonService;
        private readonly IMapper _mapper;
        public HoaDonController(IHoaDonService hoaDonService, IMapper mapper)
        {
            _hoaDonService = hoaDonService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetHoaDon()
        {
            var result = await _hoaDonService.GetHoaDons();
            if (result == null)
            {
                return NotFound("Không có hóa đơn nào");
            }
            return Ok(_mapper.Map<List<HoaDonRequest>>(result));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHoaDonById(string? id)
        {
            var hd = await _hoaDonService.GetHoaDonByIds(id);
            return Ok(_mapper.Map<HoaDonResponse>(hd));
        }
        [HttpPost]
        public async Task<IActionResult> CreateHoaDon([FromBody] HoaDonRequest hd)
        {
            await _hoaDonService.CreateHoaDons(hd);
            return Ok("Tạo Hóa Đơn Thành Công");
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] HoaDonRequest hd)
        {
            await _hoaDonService.UpdateHoaDons(hd);
            return Ok("Cập nhật Hóa Đơn Thành Công");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string? id)
        {
            await _hoaDonService.DeleteHoaDons(id);
            return Ok("Xóa Hóa Đơn Thành Công");
        }
    }
}
