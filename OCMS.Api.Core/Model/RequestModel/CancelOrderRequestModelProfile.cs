using AutoMapper;
using OCMS.Data.Access.Dto;

namespace OCMS.Api.Core.Model.RequestModel
{
    public class CancelOrderRequestModelProfile : Profile
    {
        public CancelOrderRequestModelProfile()
        {
            CreateMap<CancelOrderRequestModel, UpdateOrderDto>();
        }
    }
}
