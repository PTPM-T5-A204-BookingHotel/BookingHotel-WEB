using api.Models;
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
            MapperKhachHang();
            MapperLoaiPhong();
            MapperPhong();
        }
        private void MapperDichVu()
        {
            CreateMap<DichVu,DichVuResponse>().ReverseMap();
            CreateMap<DichVu,DichVuRepository>().ReverseMap();
        }
        private void MapperKhachHang()
        {
            CreateMap<KhachHang, KhachHangResponse>().ReverseMap();
            CreateMap<KhachHang, KhachHangRepository>().ReverseMap();
        }
        private void MapperLoaiPhong()
        {
            CreateMap<LoaiPhong, LoaiPhongResponse>().ReverseMap();
            CreateMap<LoaiPhong, LoaiPhongRepository>().ReverseMap();
        }
        private void MapperPhong()
        {
            CreateMap<Phong, PhongResponse>().ReverseMap();
            CreateMap<Phong, PhongRepository>().ReverseMap();
        }
        private void MapperHoaDonDatPhong()
        {
            CreateMap<HoaDonDatPhong, HoaDonDatPhongResponse>().ReverseMap();
            CreateMap<HoaDonDatPhong, HoaDonDatPhongRepository>().ReverseMap();
        }
    }
}
