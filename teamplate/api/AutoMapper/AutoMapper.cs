using api.Models;
using api.Models.RequestModels;
using api.Models.ResponseModels;
using AutoMapper;

namespace api.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper() 
        {
            MapperHoaDon();
        }
        private void MapperHoaDon()
        {
            CreateMap<HoaDon,HoaDonResponse>().ReverseMap();
            CreateMap<HoaDon,HoaDonRequest>().ReverseMap();
        }
    }
}
