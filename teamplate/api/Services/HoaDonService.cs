using api.Models;
using api.Models.RequestModels;
using api.Models.ResponseModels;
using api.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public interface IHoaDonService
    {
        public Task<ICollection<HoaDon>> GetHoaDons();
        public Task<HoaDon> GetHoaDonByIds(string? id);
        public Task CreateHoaDons(HoaDonRequest hd);
        public Task UpdateHoaDons( HoaDonRequest hd);
        public Task DeleteHoaDons(string? id);
    }
    public class HoaDonService : IHoaDonService
    {
        private readonly IMapper _mapper;
        private readonly HoaDonRepository _hoaDonRepository;
        public HoaDonService(IMapper mapper, HoaDonRepository hoaDonRepository)
        {
            _mapper = mapper;
            _hoaDonRepository = hoaDonRepository;
        }


        public Task CreateHoaDons(HoaDonRequest hd)
        {
            var newHd = _mapper.Map<HoaDon>(hd);
            return _hoaDonRepository.Create(newHd);
        }

        public async Task DeleteHoaDons(string? id)
        {
            await _hoaDonRepository.Delete(id);
        }

        public async Task<HoaDon?> GetHoaDonByIds(string? id)
        {
            return await _hoaDonRepository.GetId(id);
        }

        public async Task<ICollection<HoaDon>> GetHoaDons()
        {
            var hd = await _hoaDonRepository.GetAll().ToListAsync();
            return hd;
        }

        public Task UpdateHoaDons(HoaDonRequest hd)
        {
            var hdnew = _mapper.Map<HoaDon>(hd);
            return _hoaDonRepository.UpdateHD(hdnew);
        }
    }
}
