using AutoMapper;
using OCMS.Data.Access.Dto;

namespace OCMS.Api.Core.Model.RequestModel
{
    public class AddNewOrderRequestModelProfile : Profile
    {
        public AddNewOrderRequestModelProfile()
        {
            CreateMap<AddNewOrderRequestModel, OrderDto>();
        }
    }
}
