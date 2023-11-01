using api.Models.RequestModels;
using api.Models.ResponseModels;
using api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiPhongController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILoaiPhongService _loaiPhongService;
        public LoaiPhongController(IMapper mapper, ILoaiPhongService loaiPhongService)
        {
            this.mapper = mapper;
            _loaiPhongService = loaiPhongService;
        }
        [HttpGet]
        public async Task<IActionResult> GetLoaiPhong() 
        {
            var result = await _loaiPhongService.GetLoaiPhongs();
            if (result == null)
            {
                return NotFound("Không có Loại phòng nào");
            }
            return Ok(mapper.Map<List<LoaiPhongResponse>>(result));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoaiPhongById(int id)
        {
            var hd = await _loaiPhongService.GetLoaiPhongByIds(id);
            if (hd == null)
            {
                return NotFound("Không có Loại phòng nào");
            }
            return Ok(mapper.Map<LoaiPhongResponse>(hd));
        }   
    }
}
