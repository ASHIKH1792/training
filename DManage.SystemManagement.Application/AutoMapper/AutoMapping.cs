using AutoMapper;
using DManage.SystemManagement.Application.CommandHandler.DriverCommandHandler;
using DManage.SystemManagement.Application.CommandHandler.PalletCommandHandler;
using DManage.SystemManagement.Application.CommandHandler.ProductTypeCommandHandler;
using DManage.SystemManagement.Application.IntegrationEventMessage;
using DManage.SystemManagement.Application.ResponseDto;
using DManage.SystemManagement.Domain.Entities;
using System;

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
            CreateMap<DriverCreateCommand, Drivers>();
            CreateMap<PalletCreateCommand, Pallet>();
            CreateMap<ProductType, ProductTypeEventMessage>().ForMember(s=>s.ProductTypeName,v=>v.MapFrom(t=>t.Name))
                .ForMember(s => s.ProductTypeReferenceId, v => v.MapFrom(t => t.ReferenceId));

        }
    }
}
