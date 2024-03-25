using AutoMapper;
using MotoBikeShop.Data;
using MotoBikeShop.ViewModels;

namespace MotoBikeShop.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterVM, KhachHang>(); 
             //   .ForMember(kh => kh.HoTen, option => option.MapFrom(RegisterVM => RegisterVM.HoTen))
               // .ReverseMap();
        }
    }
}
