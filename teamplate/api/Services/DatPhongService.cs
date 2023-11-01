using api.Models;
using api.Models.RequestModels;
using api.Models.ResponseModels;
using api.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public interface IDatPhongService
    {
        public Task<ICollection<DatPhong>> GetDatPhong();
        public Task<DatPhong> GetPhongByIdAsync(int phongId);
        public Task CreateDatPhong(DatPhongRequest request);
        public Task UpdateDtPhong(DatPhongResponse response);
        public Task DeleteDatPhong(int phongId);
    }
    public class DatPhongService : IDatPhongService
    {
        private readonly IMapper _mapper;
        private readonly DatPhongRepository _datPhongRepository;
        public DatPhongService(IMapper mapper, DatPhongRepository datPhongRepository)
        {
            _mapper = mapper;
            _datPhongRepository = datPhongRepository;
        }
        public Task CreateDatPhong(DatPhongRequest request)
        {
            var datPhong = _mapper.Map<DatPhong>(request);
            return _datPhongRepository.Create(datPhong);
        }

        public Task DeleteDatPhong(int phongId)
        {
            return _datPhongRepository.Delete(phongId);
        }

        public  async Task<DatPhong> GetPhongByIdAsync(int phongId)
        {
            var dp = await _datPhongRepository.GetId(phongId);
            return dp;
        }

        public async Task<ICollection<DatPhong>> GetDatPhong()
        {
            var dp = await _datPhongRepository.GetAll().ToListAsync();
            return dp;
        }

        public Task UpdateDtPhong(DatPhongResponse response)
        {
            var newdatPhong = _mapper.Map<DatPhong>(response);
            return _datPhongRepository.UpdateDatPhong(newdatPhong);
        }
    }
}
