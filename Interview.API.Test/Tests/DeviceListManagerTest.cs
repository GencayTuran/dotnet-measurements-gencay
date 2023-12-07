using ABB.Interview.API.DeviceGroups.Managers;
using ABB.Interview.API.Devices.Managers;
using ABB.Interview.API.Measurements.Models;
using ABB.Interview.API.Services.Interfaces;
using Interview.API.Test.Mocks;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.API.Test.Tests
{
    [TestClass]
    public class DeviceListManagerTests
    {
        private readonly Mock<IDataHandlerService> _mockService;
        private readonly Mock<ILogger<DeviceListManager>> _mockLogger;
        private readonly DeviceListManager _manager;
        public DeviceListManagerTests()
        {
            _mockLogger = new Mock<ILogger<DeviceListManager>>();
            _mockService = new Mock<IDataHandlerService>();
            _manager = new DeviceListManager(_mockLogger.Object, _mockService.Object);
        }

        [TestMethod]
        public async Task ManageDeviceList_ValidData_ReturnsDeviceList()
        {
            //arrange
            var mockMeasurements = new DataHandlerServiceMock().GetData();
            var mockDictionary = new DataHandlerServiceMock().GetDictionaryFromData();

            _mockService.Setup(service => service.RetrieveData())
                             .ReturnsAsync(mockMeasurements);
            _mockService.Setup(service => service.DataToDictionary(mockMeasurements))
                .ReturnsAsync(mockDictionary);

            // Act
            var result = await _manager.ManageDeviceList();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task ManageDeviceList_ReturnedData_IsValid()
        {
            //arrange
            var mockMeasurements = new DataHandlerServiceMock().GetData();
            var mockDictionary = new DataHandlerServiceMock().GetDictionaryFromData();

            _mockService.Setup(service => service.RetrieveData())
                             .ReturnsAsync(mockMeasurements);
            _mockService.Setup(service => service.DataToDictionary(mockMeasurements))
                .ReturnsAsync(mockDictionary);

            //act
            var result = await _manager.ManageDeviceList();

            //assert
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public async Task ManageDeviceList_EmptyData_ThrowsException()
        {
            //arrange
            _mockService.Setup(x => x.RetrieveData()).ReturnsAsync(new List<MeasurementModel>());

            //assert
            await Assert.ThrowsExceptionAsync<Exception>(() => _manager.ManageDeviceList());
        }
    }
}
