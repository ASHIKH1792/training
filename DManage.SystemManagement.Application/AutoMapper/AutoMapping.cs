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

        }
    }
}
