using ABB.Interview.API.Measurements.Models;
using System.Diagnostics.Metrics;
using Interview.API.Test.Mocks;
using ABB.Interview.API.Services.Interfaces;
using ABB.Interview.API.Services;

namespace Interview.API.Test.Tests
{
    [TestClass]
    public class DataHandlerServiceTest
    {
        private readonly IDataHandlerService _dataHandlerService;
        public DataHandlerServiceTest()
        {
            _dataHandlerService = new DataHandlerService();
        }

        [TestMethod]
        public async Task RetrieveData_DataAtPath_Exists()
        {
            //act
            List<MeasurementModel> measurements = await _dataHandlerService.RetrieveData();

            //assert
            Assert.IsNotNull(measurements);
        }

        [TestMethod]
        public async Task RetrieveData_DataAtPath_IsComplete()
        {
            //act
            List<MeasurementModel> measurements = await _dataHandlerService.RetrieveData();

            //assert
            Assert.AreEqual(40, measurements.Count());
        }

        [TestMethod]
        public async Task DataToDictionary_ShouldReturnDictionary()
        {
            // arrange
            List<MeasurementModel> mockMeasurements = new DataHandlerServiceMock().GetData();

            // act
            Dictionary<string, MeasurementModel> measurementsDict = await _dataHandlerService.DataToDictionary(mockMeasurements);

            // assert
            Assert.IsNotNull(measurementsDict);
            Assert.AreEqual(measurementsDict.Count, mockMeasurements.Count());
        }
    }
}