using AutoMapper;
using DManage.SystemManagement.Application.ResponseDto;
using DManage.SystemManagement.Domain.Entities;

namespace DManage.SystemManagement.Application.AutoMapper
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<WareHouse, WareHouseDto>();
            CreateMap<ProductType, ProductTypeDto>();
            CreateMap<Node, NodeDto>();
            CreateMap<LicensePlateNumber, LpnDto>();
            CreateMap<Pallet, PalletDto>();
            CreateMap<PalletLpnMapping, PalletLpnDto>();
            CreateMap<WareHouseNodeMapping, WareHouseNodeDto>();
            CreateMap<WareHouseProductTypeMapping, WareHouseProductTypeDto>();

        }
    }
}
