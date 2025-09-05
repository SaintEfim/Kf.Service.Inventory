using AutoMapper;
using Kf.Service.Inventory.Data.Models;
using Kf.Service.Inventory.Domain.Models;
using Kf.Service.Inventory.Messages.Inventory;

namespace Kf.Service.Inventory.Domain;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<InventoryEntity, InventoryModel>()
            .ReverseMap();

        CreateMap<InventoryModel, InventoryData>();
    }
}
