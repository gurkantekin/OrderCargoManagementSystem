using AutoMapper;
using OCMS.Data.Access.Dto;
using OCMS.Data.Access.Entity;
using OCMS.Data.Access.Enum;
using OCMS.Data.Access.Interface;
using OCMS.Exception.Handler;
using OCMS.Exception.Handler.Model;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace OCMS.Business.Access.Manager
{
    public class OrderManager
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository<Order> _orderRepository;
        private readonly IProductRepository<Product> _productRepository;
        private readonly ICancellationRequestRepository<CancellationRequest> _cancellationRequestRepository;

        public OrderManager(IMapper mapper, IOrderRepository<Order> orderRepository, IProductRepository<Product> productRepository, ICancellationRequestRepository<CancellationRequest> cancellationRequestRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _cancellationRequestRepository = cancellationRequestRepository;
        }

        public async Task<OrderDto> AddNewOrder(OrderDto order)
        {
            try
            {
                var productCode = order.ProductCode;
                var productCategoryId = _productRepository.GetByProductCode(productCode.ToString()).CategoryId;
                var orderTotal = order.ProductPrice * order.Quantity;

                order.ShippingProviderId = productCategoryId.Equals(1) ? (int)ShipmentProviderEnum.YurtiçiKargo : (int)ShipmentProviderEnum.ArasKargo;
                order.StatusId = (int)OrderStatusEnum.New;
                order.OrderTotal = orderTotal;
                order.SubTotalWithDiscount = orderTotal - order.DiscountAmount;
                order.SubTotal = orderTotal + order.TaxAmount % order.ShippingFeeAmount;

                var orders = await _orderRepository.AddAsync(_mapper.Map<Order>(order));

                return _mapper.Map<OrderDto>(orders);
            }
            catch (System.Exception exception)
            {
                var methodBase = MethodBase.GetCurrentMethod();

                var databaseOperationException = new DatabaseOperationException(new DatabaseExceptionModel()
                {
                    NameSpace = methodBase?.DeclaringType?.Namespace,
                    ClassName = methodBase?.Name,
                    DataBaseName = RegularTableConstant.DatabaseName,
                    MethodName = methodBase?.Name,
                    Operation = DatabaseOperationEnum.Add,
                    TableName = RegularTableConstant.OrderTable
                }, exception.Message, exception.InnerException);

                throw databaseOperationException;
            }
        }

        public CancellationRequestDto GetCancellationRequest()
        {
            try
            {
                return _mapper.Map<CancellationRequestDto>(_cancellationRequestRepository.GetAll());
            }
            catch (System.Exception exception)
            {
                var methodBase = MethodBase.GetCurrentMethod();

                var databaseOperationException = new DatabaseOperationException(new DatabaseExceptionModel()
                {
                    NameSpace = methodBase?.DeclaringType?.Namespace,
                    ClassName = methodBase?.Name,
                    DataBaseName = RegularTableConstant.DatabaseName,
                    MethodName = methodBase?.Name,
                    Operation = DatabaseOperationEnum.Update,
                    TableName = RegularTableConstant.OrderTable
                }, exception.Message, exception.InnerException);

                throw databaseOperationException;
            }
        }

        public string CancelOrder(UpdateOrderDto orderDto)
        {
            try
            {
                var order = _orderRepository.GetOrderById(orderDto.Id);

                var productCode = order.ProductCode.ToString();

                var productCategory = _productRepository.GetByProductCode(productCode).CategoryId;

                if (!productCategory.Equals(1)) //Category id sorguları genişletilebilir best practice yöntem bu değil tabi ki
                {
                    _orderRepository.Update(_mapper.Map<Order>(order));

                    var cancellationRequestEntity = new CancellationRequestDto { 

                        OrderId = order.Id,
                        Descipriton = orderDto.Descipriton
                    };

                    return ApiMessageConstant.SuccessCancelOrderRequest;
                }

                return ApiMessageConstant.WaitingCancelOrderRequest;
            }
            catch (System.Exception exception)
            {
                var methodBase = MethodBase.GetCurrentMethod();

                var databaseOperationException = new DatabaseOperationException(new DatabaseExceptionModel()
                {
                    NameSpace = methodBase?.DeclaringType?.Namespace,
                    ClassName = methodBase?.Name,
                    DataBaseName = RegularTableConstant.DatabaseName,
                    MethodName = methodBase?.Name,
                    Operation = DatabaseOperationEnum.Update,
                    TableName = RegularTableConstant.OrderTable
                }, exception.Message, exception.InnerException);

                throw databaseOperationException;
            }
        }

        public bool ApproveOrderCancellationRequest(CancelOrderDto orderDto)
        {
            try
            {
                var order = _orderRepository.GetOrderById(orderDto.OrderId);

                order.StatusId = (int)OrderStatusEnum.Canceled;

                var cancelOrderRequest = _cancellationRequestRepository.GetOrderById(order.Id);

                _cancellationRequestRepository.Update(cancelOrderRequest);

                return true;
            }
            catch (System.Exception exception)
            {
                var methodBase = MethodBase.GetCurrentMethod();

                var databaseOperationException = new DatabaseOperationException(new DatabaseExceptionModel()
                {
                    NameSpace = methodBase?.DeclaringType?.Namespace,
                    ClassName = methodBase?.Name,
                    DataBaseName = RegularTableConstant.DatabaseName,
                    MethodName = methodBase?.Name,
                    Operation = DatabaseOperationEnum.Update,
                    TableName = RegularTableConstant.OrderTable
                }, exception.Message, exception.InnerException);

                throw databaseOperationException;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var orders = _orderRepository.GetAll().Where(x => x.Id.Equals(id)).ToList();

                foreach (var order in orders)
                {
                    _orderRepository.Delete(_mapper.Map<Order>(order));
                }

                return true;
            }
            catch (System.Exception exception)
            {
                var methodBase = MethodBase.GetCurrentMethod();

                var databaseOperationException = new DatabaseOperationException(new DatabaseExceptionModel()
                {
                    NameSpace = methodBase?.DeclaringType?.Namespace,
                    ClassName = methodBase?.Name,
                    DataBaseName = RegularTableConstant.DatabaseName,
                    MethodName = methodBase?.Name,
                    Operation = DatabaseOperationEnum.Delete,
                    TableName = RegularTableConstant.OrderTable
                }, exception.Message, exception.InnerException);

                throw databaseOperationException;
            }
        }
    }
}
