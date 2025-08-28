using AutoMapper;
using Kf.Service.Inventory.API.Models;
using Kf.Service.Inventory.API.Models.Base;
using Kf.Service.Inventory.Domain.Models;

namespace Kf.Service.Inventory.API;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<InventoryModel, InventoryDto>();

        CreateMap<InventoryModel, CreateActionResultDto>();

        CreateMap<InventoryCreateDto, InventoryModel>();

        CreateMap<InventoryUpdateDto, InventoryModel>()
            .ReverseMap();
    }
}
