using api.Models.ResponseModels;
using api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhongController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPhongService phongService;
        public PhongController(IMapper mapper, IPhongService phongService)
        {
            this.mapper = mapper;
            this.phongService = phongService;
        }
        [HttpGet]
        public async Task<IActionResult> GetPhong() 
        {
            var phong = await phongService.GetPhongs();
            if(phong == null)
            {
                return NotFound("Không có bất cứ phòng nào");
            }
            return Ok(mapper.Map<List<PhongResponse>>(phong));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhongById(int id)
        {
            var phong = await phongService.GetPhongByIds(id);
            if(phong == null)
            {
                return NotFound("Không có phòng này");
            }
            return Ok(mapper.Map<PhongResponse>(phong));
        }
    }
}
