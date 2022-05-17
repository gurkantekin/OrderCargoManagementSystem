using AutoMapper;
using OCMS.Data.Access.Dto;

namespace OCMS.Api.Core.Model.RequestModel
{
    public class ApproveCancelOrderRequestProfile : Profile
    {
        public ApproveCancelOrderRequestProfile()
        {
            CreateMap<ApproveCancelOrderRequestModel, CancelOrderDto>();
        }
    }
}
