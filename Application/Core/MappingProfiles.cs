using AutoMapper;
using Domain;

namespace Application;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Product,Product>();
        CreateMap<Product,ProductDto>()
           .ForMember(d=>d.Categories,o=>o.MapFrom( s=>s.Categories))
           .ForMember(d=>d.stock,o=>o.MapFrom( s=>s.ProductStock.Count));
        
        CreateMap<ProductCategory,CategoryDto>()
            .ForMember(d=>d.Id , o => o.MapFrom(s=>s.Category.Id))
            .ForMember(d=>d.Name , o => o.MapFrom(s=>s.Category.Name)); 

    }
}

