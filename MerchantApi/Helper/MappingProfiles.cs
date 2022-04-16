using AutoMapper;
using MerchantApi.Dto;
using MerchantApi.Models;

namespace MerchantApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<MerchantDto, Merchant>();
            CreateMap<Merchant, MerchantDto>();
            CreateMap<StoreDto, Store>();
            CreateMap<Store, StoreDto>();   
        }
    }
}
