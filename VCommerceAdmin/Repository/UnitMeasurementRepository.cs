using Microsoft.EntityFrameworkCore;
using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Data;
using VCommerceAdmin.Helpers;
using VCommerceAdmin.Models;
using VCommerceAdmin.Repository.Interface;

namespace VCommerceAdmin.Repository
{
    public class UnitMeasurementRepository : IUnitMeasurementRepository
    {
        private readonly IDbContextFactory<VcommerceContext> _contextFactory;

        public UnitMeasurementRepository(IDbContextFactory<VcommerceContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public CreateUnitMeasurementResponse CreateUnitMeasurement(CreateUnitMeasurementRequest req, out int code, out string msg)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var newUnitMeasurement = new Um
                    {
                        Name = req.Name,
                        Memo = req.Memo,
                        Abbreviation = req.Abbreviation,
                        CreatedBy = 1,
                        CreatedDate = GlobalFunction.GetCurrentDateTime(),
                        StatusId = req.StatusId
                    };
                    context.Ums.Add(newUnitMeasurement);
                    context.SaveChanges();
                    code = ApiReturnError.Success.Value();
                    msg = ApiReturnError.Success.Description();
                    return new CreateUnitMeasurementResponse(newUnitMeasurement);
                }
                catch (Exception ex)
                {
                    code = ApiReturnError.DbError.Value();
                    msg = ApiReturnError.DbError.Description();
                    GlobalFunction.RecordErrorLog("UnitMeasurementRepository/CreateUnitMeasurement", ex, context);
                    return null;
                }
            }
        }

        public List<GetUnitMeasurementsResponse> GetUnitMeasurements(GetUnitMeasurementsRequest req, out int code, out string msg)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var result = context.Ums.Select(x => new GetUnitMeasurementsResponse
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Memo = x.Memo,
                        Abbreviation= x.Abbreviation,
                        CreatedBy = x.CreatedBy,
                        CreatedDate = x.CreatedDate,
                        ModifiedBy = x.ModifiedBy,
                        ModifiedDate = x.ModifiedDate,
                        StatusId = x.StatusId,
                        StatusName = x.Status.Name,
                    }).OrderByDescending(x => x.Id).Skip(req.Skip).Take(req.Limit).ToList();
                    code = ApiReturnError.Success.Value();
                    msg = ApiReturnError.Success.Description();
                    return new List<GetUnitMeasurementsResponse>(result);
                }
                catch (Exception ex)
                {
                    code = ApiReturnError.DbError.Value();
                    msg = ApiReturnError.DbError.Description();
                    GlobalFunction.RecordErrorLog("UnitMeasurementRepository/GetUnitMeasurements", ex, context);
                    return null;
                }
            }
        }

        public UpdateUnitMeasurementResponse UpdateUnitMeasurement(UpdateUnitMeasurementRequest req, out int code, out string msg)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var currentUnitMeasurement = context.Ums.Find(req.Id);
                    currentUnitMeasurement.Name = req.Name;
                    currentUnitMeasurement.Memo = req.Memo;
                    currentUnitMeasurement.Abbreviation = req.Abbreviation;
                    currentUnitMeasurement.StatusId = req.StatusId;
                    currentUnitMeasurement.ModifiedBy = 1;
                    currentUnitMeasurement.ModifiedDate = GlobalFunction.GetCurrentDateTime();
                    context.SaveChanges();
                    code = ApiReturnError.Success.Value();
                    msg = ApiReturnError.Success.Description();
                    return new UpdateUnitMeasurementResponse(currentUnitMeasurement);
                }
                catch (Exception ex)
                {
                    code = ApiReturnError.DbError.Value();
                    msg = ApiReturnError.DbError.Description();
                    GlobalFunction.RecordErrorLog("UnitMeasurementRepository/UpdateUnitMeasurement", ex, context);
                    return null;
                }
            }
        }
    }
}