using api.Models;
using api.Models.RequestModels;
using api.Models.ResponseModels;
using api.Repositories;
using AutoMapper;

namespace api.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper() 
        {
            MapperDichVu();
            MapperHoaDonDatPhong();
            
        }
        private void MapperDichVu()
        {
            CreateMap<DichVu,DichVuResponse>().ReverseMap();
        }
        
       
        private void MapperHoaDonDatPhong()
        {
            CreateMap<HoaDonDatPhong, HoaDonDatPhongResponse>().ReverseMap();
            CreateMap<HoaDonDatPhong, HoaDonDatPhongRepository>().ReverseMap();
            CreateMap<HoaDonDatPhongRequest,HoaDonDatPhong>().ReverseMap();
        }
    }
}
