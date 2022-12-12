using AutoMapper;
using BLL.DTO;
using BLL.Helpers;
using DAL.Entities;
using DAL.Entities.OrderAggregate;

namespace BLL.Mapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
            
            CreateMap<Address, AddressDto>().ReverseMap();
            
            CreateMap<AddressDto, AddressAggregate>();
            
            CreateMap<CustomerBasketDto, CustomerBasket>();
            
            CreateMap<BasketItemDto, BasketItem>();
            
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));
            
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s =>  s.ItemOrdered.ProductItemId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s =>  s.ItemOrdered.ProductName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s =>  s.ItemOrdered.PictureUrl))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());
            
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, SignUpDto>().ReverseMap();
        }
    }
}