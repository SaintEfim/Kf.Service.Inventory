using AutoMapper;
using Kf.Service.Inventory.Data.Models;
using Kf.Service.Inventory.Domain.Models;

namespace Kf.Service.Inventory.Domain;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<InventoryEntity, InventoryModel>()
            .ReverseMap();
    }
}
