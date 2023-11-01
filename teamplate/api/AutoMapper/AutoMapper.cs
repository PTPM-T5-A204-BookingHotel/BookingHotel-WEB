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
            MapperLoaiPhong();
            MapperPhong();
            MapperDatPhong();
        }
        private void MapperHoaDon()
        {
            CreateMap<HoaDon,HoaDonResponse>().ReverseMap();
            CreateMap<HoaDon,HoaDonRequest>().ReverseMap();
        }
        private void MapperLoaiPhong()
        {
            CreateMap<LoaiPhong,LoaiPhongResponse>().ReverseMap();
            CreateMap<LoaiPhong,LoaiPhongRequest>().ReverseMap();
        }
        private void MapperPhong()
        {
            CreateMap<Phong,PhongRequest>().ReverseMap();
            CreateMap<Phong,PhongResponse>().ReverseMap();
        }
        private void MapperDatPhong()
        {
            CreateMap<DatPhong,DatPhongResponse>().ReverseMap();
            CreateMap<DatPhong,DatPhongRequest>().ReverseMap();
            CreateMap<DatPhongRequest,DatPhongResponse>().ReverseMap();
        }
    }
}
