using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OCMS.Api.Core.Model.RequestModel;
using OCMS.Api.Core.Model.ResponseModel;
using OCMS.Business.Access.Manager;
using OCMS.Data.Access.Dto;
using OCMS.Exception.Handler.Model;
using System.Threading.Tasks;

namespace OCMS.Api.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderManagementController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly OrderManager _orderManager;

        public OrderManagementController(IMapper mapper, OrderManager orderManager)
        {
            _mapper = mapper;
            _orderManager = orderManager;
        }

        [HttpPost]
        [Route("create_order")]
        public async Task<ObjectResult> CreateOrder([FromBody] AddNewOrderRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponseModel<ModelStateDictionary>()
                {
                    Status = false,
                    Message = string.Empty,
                    Error = ModelState
                });
            }
            try
            {
                var response = await _orderManager.AddNewOrder(_mapper.Map<OrderDto>(model));

                if (response != null)
                    return Ok(new SuccessResponseModel<OrderDto>()
                    {
                        Status = true,
                        Model = response
                    });
                return BadRequest(new ErrorResponseModel<System.Exception>()
                {
                    Status = false,
                    Message = ErrorMessageConstant.GeneralErrorMessage,
                    Error = null
                });
            }
            catch (System.Exception exception)
            {
                return BadRequest(new ErrorResponseModel<System.Exception>()
                {
                    Status = false,
                    Message = exception.Message,
                    Error = exception
                });
            }
        }

        [HttpPost]
        [Route("cancel_order")]
        public ObjectResult CancelOrder([FromBody] CancelOrderRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponseModel<ModelStateDictionary>()
                {
                    Status = false,
                    Message = string.Empty,
                    Error = ModelState
                });
            }
            try
            {
                var response = _orderManager.CancelOrder(_mapper.Map<UpdateOrderDto>(model));

                return Ok(new SuccessResponseModel<string>()
                {
                    Status = true,
                    Model = response
                });
            }
            catch (System.Exception exception)
            {
                return BadRequest(new ErrorResponseModel<System.Exception>()
                {
                    Status = false,
                    Message = exception.Message,
                    Error = exception
                });
            }
        }

        [HttpPost]
        [Route("approve_cancellation_request")]
        public ObjectResult ApproveCancellationRequest([FromBody] ApproveCancelOrderRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponseModel<ModelStateDictionary>()
                {
                    Status = false,
                    Message = string.Empty,
                    Error = ModelState
                });
            }
            try
            {
                var response = _orderManager.ApproveOrderCancellationRequest(_mapper.Map<CancelOrderDto>(model));

                return Ok(new SuccessResponseModel<bool>()
                {
                    Status = true,
                    Model = response
                });
            }
            catch (System.Exception exception)
            {
                return BadRequest(new ErrorResponseModel<System.Exception>()
                {
                    Status = false,
                    Message = exception.Message,
                    Error = exception
                });
            }
        }
    }
}
