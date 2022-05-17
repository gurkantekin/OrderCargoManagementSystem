using AutoMapper;
using OCMS.Data.Access.Entity;

namespace OCMS.Data.Access.Dto
{
    class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
        }
    }
}
