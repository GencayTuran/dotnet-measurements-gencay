﻿using ABB.Interview.API.DeviceGroups.Managers;
using ABB.Interview.API.DeviceGroups.Managers.Interfaces;
using ABB.Interview.API.DeviceGroups.Models;
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
    public class DeviceGroupManagerTest
    {
        private readonly Mock<IDataHandlerService> _mockService;
        private readonly Mock<ILogger<DeviceGroupManager>> _mockLogger;
        private readonly DeviceGroupManager _manager;
        public DeviceGroupManagerTest()
        {
            _mockLogger = new Mock<ILogger<DeviceGroupManager>>();
            _mockService = new Mock<IDataHandlerService>();
            _manager = new DeviceGroupManager(_mockLogger.Object, _mockService.Object);
        }

        [TestMethod]
        public async Task HandleGroups_ShouldReturn_ListOfDeviceGroupListModel()
        {
            var mockMeasurements = new DataHandlerServiceMock().GetData();

            //arrange
            _mockService.Setup(service => service.RetrieveData())
                             .ReturnsAsync(mockMeasurements); 

            //act
            List<DeviceGroupListModel> result = await _manager.MapDeviceGroups();

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task HandleGroups_RetrieveData_ReturnsNull_ShouldThrow_Exception()
        {
            var mockMeasurements = new DataHandlerServiceMock().GetData();

            //arrange
            _mockService.Setup(service => service.RetrieveData())
                             .ReturnsAsync(new List<MeasurementModel>());

            //assert
            await Assert.ThrowsExceptionAsync<Exception>(async()  => await _manager.MapDeviceGroups());
        }
    }
}
