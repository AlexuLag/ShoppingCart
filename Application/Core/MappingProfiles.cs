using Application.Orders;
using AutoMapper;
using Domain;

namespace Application;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, Product>();
        CreateMap<Product, ProductDto>()
           .ForMember(d => d.Categories, o => o.MapFrom(s => s.Categories))
           .ForMember(d => d.stock, o => o.MapFrom(s => s.ProductStock.Count(a => a.Status == "S")));

        CreateMap<ProductCategory, CategoryDto>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Category.Id))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Category.Name));

        CreateMap<Order, OrderDto>()
            .ForMember(d => d.Items, o => o.MapFrom(s => s.OrderDetails.ToList()))
            .ForMember(d => d.UserId, o => o.MapFrom(s => s.CustomerId));

            
        CreateMap<OrderDetail, OrderDetailDto>()
            .ForMember(d => d.Product, o => o.MapFrom(s => s.Product))
            .ForMember(d => d.Quantity, o => o.MapFrom(s => s.Quantity));
            







    }
}

