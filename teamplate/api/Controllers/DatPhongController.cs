using api.Models.RequestModels;
using api.Models.ResponseModels;
using api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.IO;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatPhongController : ControllerBase
    {
        
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        private readonly IDatPhongService _datPhongService;
        public DatPhongController(IMapper mapper, IDatPhongService datPhongService, IWebHostEnvironment webHostEnvironment)
        {
            _datPhongService = datPhongService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dp = await _datPhongService.GetDatPhong();
            if(dp == null)
            {
                return NotFound("Không tìm thấy bất cứ thông tin đặt phòng");
            }
            return Ok(dp);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            var dp = await _datPhongService.GetPhongByIdAsync(id);
            if (dp == null)
            {
                return NotFound("Không tìm thấy bất cứ thông tin đặt phòng");
            }
            return Ok(dp);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DatPhongRequest dp)
        {
            var newdp = _datPhongService.CreateDatPhong(dp);
            return Ok("Đặt Phòng Thành Công");
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DatPhongResponse dp)
        {
            await _datPhongService.UpdateDtPhong(dp);
            return Ok("Sửa Thông Tin Đặt Phòng Thành Công");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            await _datPhongService.DeleteDatPhong(id);
            return Ok("Xóa Thông Tin Đặt Phòng Thành Công");
        }
        [HttpPut("UploadImage")]
        public async Task<IActionResult> UploadImage(int MaDp, IFormFile formFile)
        {
            APIResponse response = new APIResponse();
            try
            {
                string Filepath = GetFilepath(MaDp);

                if (!System.IO.Directory.Exists(Filepath))
                {
                    System.IO.Directory.CreateDirectory(Filepath);
                }

                string imagepath = Filepath + "\\" + MaDp + ".png";

                if (System.IO.File.Exists(imagepath))
                {
                    System.IO.File.Delete(imagepath);
                }

                using (FileStream stream = System.IO.File.Create(imagepath))
                {
                    await formFile.CopyToAsync(stream);
                    response.ResponseCode = 200;
                    response.Result = "pass";
                    SaveImagePathToDatabase(MaDp, imagepath);
                }
            }
            catch (Exception ex)
            {
                response.Errormessage = ex.Message;
            }
            return Ok(response);
        }
        private void SaveImagePathToDatabase(int MaDp, string imagePath)
        {
            string _connectionString = "Server=Dainn;Database=QLKhachSan;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE DatPhong SET HinhAnh = @ImagePath WHERE MaDP = @MaDp";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.Add("@ImagePath", SqlDbType.NVarChar, -1).Value = imagePath;
                    command.Parameters.Add("@MaDp", SqlDbType.Int).Value = MaDp;

                    command.ExecuteNonQuery();
                }
            }
        }
        [NonAction]
        private string GetFilepath(int madp)
        {
            return this._webHostEnvironment.WebRootPath + "\\Upload\\KhachHang\\" + madp;
        }
    }
}
