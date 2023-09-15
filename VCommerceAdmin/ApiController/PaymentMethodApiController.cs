using Microsoft.AspNetCore.Mvc;
using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Helpers;
using VCommerceAdmin.Repository.Interface;

namespace VCommerceAdmin.ApiController
{
    [Route("api")]
    [ApiController]
    public class PaymentMethodApiController : ControllerBase
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public PaymentMethodApiController(IPaymentMethodRepository PaymentMethodRepository)
        {
            _paymentMethodRepository = PaymentMethodRepository;
        }

        [HttpPost("v1/payment-method/create-payment-method")]
        public ApiResponse<CreatePaymentMethodResponse> CreatePaymentMethod([FromBody] CreatePaymentMethodRequest req)
        {
            var result = _paymentMethodRepository.CreatePaymentMethod(req, out int code, out string msg);
            return new ApiResponse<CreatePaymentMethodResponse>(result, code, msg);
        }

        [HttpPost("v1/payment-method/get-payment-methods")]
        public ApiResponse<List<GetPaymentMethodsResponse>> GetPaymentMethod([FromBody] GetPaymentMethodsRequest req)
        {
            var result = _paymentMethodRepository.GetPaymentMethods(req, out int code, out string msg);
            return new ApiResponse<List<GetPaymentMethodsResponse>>(result, code, msg);
        }

        [HttpPost("v1/payment-method/update-payment-method")]
        public ApiResponse<UpdatePaymentMethodResponse> UpdatePaymentMethod([FromBody] UpdatePaymentMethodRequest req)
        {
            var result = _paymentMethodRepository.UpdatePaymentMethod(req, out int code, out string msg);
            return new ApiResponse<UpdatePaymentMethodResponse>(result, code, msg);
        }
    }
}