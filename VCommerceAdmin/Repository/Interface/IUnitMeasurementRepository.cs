using VCommerceAdmin.ApiModels;

namespace VCommerceAdmin.Repository.Interface
{
    public interface IUnitMeasurementRepository
    {
        List<GetUnitMeasurementsResponse> GetUnitMeasurements(GetUnitMeasurementsRequest req, out int code, out string msg);

        CreateUnitMeasurementResponse CreateUnitMeasurement(CreateUnitMeasurementRequest req, out int code, out string msg);

        UpdateUnitMeasurementResponse UpdateUnitMeasurement(UpdateUnitMeasurementRequest req, out int code, out string msg);
    }
}