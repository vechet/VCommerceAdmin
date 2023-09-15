using VCommerceAdmin.ApiModels;

namespace VCommerceAdmin.Repository.Interface
{
    public interface IPaymentMethodRepository
    {
        List<GetPaymentMethodsResponse> GetPaymentMethods(GetPaymentMethodsRequest req, out int code, out string msg);

        CreatePaymentMethodResponse CreatePaymentMethod(CreatePaymentMethodRequest req, out int code, out string msg);

        UpdatePaymentMethodResponse UpdatePaymentMethod(UpdatePaymentMethodRequest req, out int code, out string msg);
    }
}