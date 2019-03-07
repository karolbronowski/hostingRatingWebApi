using AutoMapper;
using hostingRatingWebApi.DTO;
using hostingRatingWebApi.Models;

namespace hostingRatingWebApi.Mappers
{
    public static class AutoMapperConfig
    {
         public static IMapper Initialize()
        => new MapperConfiguration(cfg =>{
                cfg.CreateMap<User,UserDTO>();
                cfg.CreateMap<Brand,BrandDTO>();
                cfg.CreateMap<BrandPackage,BrandPackageDTO>();
        })
        .CreateMapper();
    }
}