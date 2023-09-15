using Microsoft.EntityFrameworkCore;
using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Data;
using VCommerceAdmin.Helpers;
using VCommerceAdmin.Models;
using VCommerceAdmin.Repository.Interface;

namespace VCommerceAdmin.Repository
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly IDbContextFactory<VcommerceContext> _contextFactory;

        public PaymentMethodRepository(IDbContextFactory<VcommerceContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public CreatePaymentMethodResponse CreatePaymentMethod(CreatePaymentMethodRequest req, out int code, out string msg)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var newPaymentMethod = new PaymentMethod
                    {
                        Name = req.Name,
                        Memo = req.Memo,
                        CreatedBy = 1,
                        CreatedDate = GlobalFunction.GetCurrentDateTime(),
                        StatusId = req.StatusId
                    };
                    context.PaymentMethods.Add(newPaymentMethod);
                    context.SaveChanges();
                    code = ApiReturnError.Success.Value();
                    msg = ApiReturnError.Success.Description();
                    return new CreatePaymentMethodResponse(newPaymentMethod);
                }
                catch (Exception ex)
                {
                    code = ApiReturnError.DbError.Value();
                    msg = ApiReturnError.DbError.Description();
                    GlobalFunction.RecordErrorLog("PaymentMethodRepository/CreatePaymentMethod", ex, context);
                    return null;
                }
            }
        }

        public List<GetPaymentMethodsResponse> GetPaymentMethods(GetPaymentMethodsRequest req, out int code, out string msg)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var result = context.PaymentMethods.Select(x => new GetPaymentMethodsResponse
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Memo = x.Memo,
                        CreatedBy = x.CreatedBy,
                        CreatedDate = x.CreatedDate,
                        ModifiedBy = x.ModifiedBy,
                        ModifiedDate = x.ModifiedDate,
                        StatusId = x.StatusId,
                        StatusName = x.Status.Name,
                    }).OrderByDescending(x => x.Id).Skip(req.Skip).Take(req.Limit).ToList();
                    code = ApiReturnError.Success.Value();
                    msg = ApiReturnError.Success.Description();
                    return new List<GetPaymentMethodsResponse>(result);
                }
                catch (Exception ex)
                {
                    code = ApiReturnError.DbError.Value();
                    msg = ApiReturnError.DbError.Description();
                    GlobalFunction.RecordErrorLog("PaymentMethodRepository/GetPaymentMethods", ex, context);
                    return null;
                }
            }
        }

        public UpdatePaymentMethodResponse UpdatePaymentMethod(UpdatePaymentMethodRequest req, out int code, out string msg)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var currentPaymentMethod = context.PaymentMethods.Find(req.Id);
                    currentPaymentMethod.Name = req.Name;
                    currentPaymentMethod.Memo = req.Memo;
                    currentPaymentMethod.StatusId = req.StatusId;
                    currentPaymentMethod.ModifiedBy = 1;
                    currentPaymentMethod.ModifiedDate = GlobalFunction.GetCurrentDateTime();
                    context.SaveChanges();
                    code = ApiReturnError.Success.Value();
                    msg = ApiReturnError.Success.Description();
                    return new UpdatePaymentMethodResponse(currentPaymentMethod);
                }
                catch (Exception ex)
                {
                    code = ApiReturnError.DbError.Value();
                    msg = ApiReturnError.DbError.Description();
                    GlobalFunction.RecordErrorLog("PaymentMethodRepository/UpdatePaymentMethod", ex, context);
                    return null;
                }
            }
        }
    }
}