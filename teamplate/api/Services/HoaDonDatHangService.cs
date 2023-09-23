using api.Models;
using api.Models.RequestModels;
using api.Models.ResponseModels;
using api.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public interface IHoaDonDatHangService
    {
        public Task<ICollection<HoaDonDatPhong>> GetHoaDons();
        public Task<HoaDonDatPhong> GetHoaDon(int Id);
        public Task CreateHoaDon(HoaDonDatPhongRequest hoaDon);
        public Task UpdateHoaDon(int Id, HoaDonDatPhongResponse hoaDon);
        public Task DeleteHoaDon(int Id);
    }
    public class HoaDonDatHangService : IHoaDonDatHangService
    {
        private readonly IMapper _mapper;
        private readonly HoaDonDatPhongRepository _hoadonDatPhongRepository;
        public HoaDonDatHangService(IMapper mapper, HoaDonDatPhongRepository hoadonDatPhongRepository)
        {
            _mapper = mapper;
            _hoadonDatPhongRepository = hoadonDatPhongRepository;
        }

        public async Task CreateHoaDon(HoaDonDatPhongRequest hoaDon)
        {
            var newMap = _mapper.Map<HoaDonDatPhong>(hoaDon);
            var newHoaDon = _hoadonDatPhongRepository.Create(newMap);
        }

        public async Task DeleteHoaDon(int Id)
        {
            await _hoadonDatPhongRepository.Delete(Id);
        }

        public async Task<HoaDonDatPhong> GetHoaDon(int Id)
        {
            var hoaDon = await _hoadonDatPhongRepository.GetId(Id);
            return hoaDon;
        }

        public async Task<ICollection<HoaDonDatPhong>> GetHoaDons()
        {
            var hoaDon = await _hoadonDatPhongRepository.GetAll().ToListAsync();
            return hoaDon;
        }

        public async Task UpdateHoaDon(int Id, HoaDonDatPhongResponse hoaDon)
        {
            if (Id == hoaDon.Id)
            {
                var update = _mapper.Map<HoaDonDatPhong>(hoaDon);
                _hoadonDatPhongRepository.Edit(update);
            }
        }
    }
}
