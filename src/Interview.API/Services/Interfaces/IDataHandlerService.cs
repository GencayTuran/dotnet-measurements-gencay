using ABB.Interview.API.Measurements.Models;

namespace ABB.Interview.API.Services.Interfaces
{
    public interface IDataHandlerService
    {
        Task<List<MeasurementModel>> RetrieveData();
        Task<Dictionary<string,MeasurementModel>> DataToDictionary(List<MeasurementModel> measurements);
    }
}