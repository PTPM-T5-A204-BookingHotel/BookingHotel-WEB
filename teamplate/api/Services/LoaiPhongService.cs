using api.Models;
using api.Models.RequestModels;
using api.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public interface ILoaiPhongService
    {
        public Task<ICollection<LoaiPhong>> GetLoaiPhongs();
        public Task<LoaiPhong> GetLoaiPhongByIds(int id);
    }
    public class LoaiPhongService : ILoaiPhongService
    {
        private readonly IMapper mapper;
        private readonly LoaiPhongRepository loaiPhongRepository;
        public LoaiPhongService(IMapper mapper, LoaiPhongRepository loaiPhongRepository)
        {
            this.mapper = mapper;
            this.loaiPhongRepository = loaiPhongRepository;
        }
        public async Task<LoaiPhong> GetLoaiPhongByIds(int id)
        {
            return await loaiPhongRepository.GetId(id);
        }

        public async Task<ICollection<LoaiPhong>> GetLoaiPhongs()
        {
            return await loaiPhongRepository.GetAll().ToListAsync();
        }
    }
}
