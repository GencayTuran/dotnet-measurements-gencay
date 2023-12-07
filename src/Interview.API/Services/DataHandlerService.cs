using ABB.Interview.API.Helpers;
using ABB.Interview.API.Measurements.Models;
using ABB.Interview.API.Services.Interfaces;
using Newtonsoft.Json;

namespace ABB.Interview.API.Services
{
    public class DataHandlerService : IDataHandlerService
    {
        private string filePath = Path.Combine(Directory.GetCurrentDirectory(), "data", "measurements.json");

        public async Task<List<MeasurementModel>> RetrieveData()
        {
            var jsonData = File.ReadAllText(filePath);
            List<MeasurementModel> measurements = JsonConvert.DeserializeObject<List<MeasurementModel>>(jsonData);
            return measurements;
        }

        public async Task<Dictionary<string, MeasurementModel>> DataToDictionary(List<MeasurementModel> measurements)
        {
            Dictionary<string, MeasurementModel> measurementsDict = measurements.ToDictionary(m => HashKeyHelper.GetHashKey(m), StringComparer.OrdinalIgnoreCase);
            return measurementsDict;
        }
    }
}
