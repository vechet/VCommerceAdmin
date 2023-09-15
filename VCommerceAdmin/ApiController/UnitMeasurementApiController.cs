using Microsoft.AspNetCore.Mvc;
using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Helpers;
using VCommerceAdmin.Repository.Interface;

namespace VCommerceAdmin.ApiController
{
    [Route("api")]
    [ApiController]
    public class UnitMeasurementApiController : ControllerBase
    {
        private readonly IUnitMeasurementRepository _UnitMeasurementRepository;

        public UnitMeasurementApiController(IUnitMeasurementRepository UnitMeasurementRepository)
        {
            _UnitMeasurementRepository = UnitMeasurementRepository;
        }

        [HttpPost("v1/unit-measurement/create-unit-measurement")]
        public ApiResponse<CreateUnitMeasurementResponse> CreateUnitMeasurement([FromBody] CreateUnitMeasurementRequest req)
        {
            var result = _UnitMeasurementRepository.CreateUnitMeasurement(req, out int code, out string msg);
            return new ApiResponse<CreateUnitMeasurementResponse>(result, code, msg);
        }

        [HttpPost("v1/unit-measurement/get-unit-measurements")]
        public ApiResponse<List<GetUnitMeasurementsResponse>> GetUnitMeasurements([FromBody] GetUnitMeasurementsRequest req)
        {
            var result = _UnitMeasurementRepository.GetUnitMeasurements(req, out int code, out string msg);
            return new ApiResponse<List<GetUnitMeasurementsResponse>>(result, code, msg);
        }

        [HttpPost("v1/unit-measurement/update-unit-measurement")]
        public ApiResponse<UpdateUnitMeasurementResponse> UpdateUnitMeasurement([FromBody] UpdateUnitMeasurementRequest req)
        {
            var result = _UnitMeasurementRepository.UpdateUnitMeasurement(req, out int code, out string msg);
            return new ApiResponse<UpdateUnitMeasurementResponse>(result, code, msg);
        }
    }
}