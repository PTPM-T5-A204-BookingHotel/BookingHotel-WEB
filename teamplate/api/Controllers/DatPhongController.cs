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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DatPhongController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        private readonly IDatPhongService _datPhongService;
        public DatPhongController(IMapper mapper, IDatPhongService datPhongService, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _datPhongService = datPhongService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
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
        public async Task<IActionResult> Post(DatPhongRequest dp)
        {
            var isSuccess = await _datPhongService.CreateDatPhong(dp);

            if (isSuccess)
            {
                return Ok("Đặt Phòng Thành Công");
            }
            else
            {
                return BadRequest("Đã xảy ra lỗi khi đặt phòng.");
            }
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
        [HttpPost]
        public IActionResult UploadImage([FromForm] HinhDatPhongResponse model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string Filepath = GetFilepath(model.MaDp);

                    if (!System.IO.Directory.Exists(Filepath))
                    {
                        System.IO.Directory.CreateDirectory(Filepath);
                    }

                    string fileExtension = Path.GetExtension(model.HinhAnh.FileName);
                    string imagepath = Path.Combine(Filepath, model.MaDp + fileExtension);

                    if (System.IO.File.Exists(imagepath))
                    {
                        System.IO.File.Delete(imagepath);
                    }

                    using (FileStream stream = System.IO.File.Create(imagepath))
                    {
                        model.HinhAnh.CopyTo(stream);
                        SaveImagePathToDatabase(model.MaDp, imagepath);

                        APIResponse response = new APIResponse
                        {
                            ResponseCode = 200,
                            Result = "pass"
                        };

                        return Ok(response);
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(new { ErrorMessage = ex.Message });
                }
            }

            return BadRequest(new { ErrorMessage = "Invalid model state." });
        }

        private void SaveImagePathToDatabase(int MaDp, string imagePath)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
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
