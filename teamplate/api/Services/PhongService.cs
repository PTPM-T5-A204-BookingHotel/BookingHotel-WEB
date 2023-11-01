using api.Models;
using api.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public interface IPhongService
    {
        public Task<ICollection<Phong>> GetPhongs();
        public Task<Phong> GetPhongByIds(int id);
    }
    public class PhongService : IPhongService
    {
        private readonly IMapper mapper;
        private readonly PhongRepository phongRepository;
        public PhongService(IMapper mapper, PhongRepository phongRepository)
        {
            this.mapper = mapper;
            this.phongRepository = phongRepository;
        }

        public async Task<Phong> GetPhongByIds(int id)
        {
            return await phongRepository.GetId(id);
        }

        public async Task<ICollection<Phong>> GetPhongs()
        {
            return await phongRepository.GetAll().ToListAsync();
        }
    }
}
