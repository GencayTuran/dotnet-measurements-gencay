using ABB.Interview.API.Measurements.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.API.Test.Mocks
{
    public class DataHandlerServiceMock
    {
        private List<MeasurementModel> _data = new List<MeasurementModel>()
        {
            new MeasurementModel()
            {
                ResourceId = "49e258fe-9d40-43b4-9a29-31f82ad5ec15",
                DeviceName = "device_1",
                DeviceGroup = "group_a",
                Direction = "out",
                Power = new List<PowerListModel>()
                {
                    new PowerListModel()
                    {
                        Min = 29.163184452205893,
                        Max = 65.44317306454077,
                        Avg = 47.303178758373335,
                        Timestamp = 1626300000
                    },
                    new PowerListModel()
                    {
                        Min = 13.620455434219808,
                        Max = 99.74979414798125,
                        Avg = 56.68512479110053,
                        Timestamp = 1626300900
                    },
                }
            },
            new MeasurementModel()
            {
                ResourceId = "4d5b9f5e-2b18-41bd-96f0-96674ed9846a",
                DeviceName = "device_2",
                DeviceGroup = "group_a",
                Direction = "out",
                Power = new List<PowerListModel>()
                {
                    new PowerListModel()
                    {
                        Min = 43.369282856064075,
                        Max = 63.832139591421075,
                        Avg = 53.60071122374258,
                        Timestamp = 1626300000
                    },
                    new PowerListModel()
                    {
                        Min = 43.70940488552223,
                        Max = 60.62410635020656,
                        Avg = 52.166755617864396,
                        Timestamp = 1626300900
                    },
                }
            },
            new MeasurementModel()
            {
                ResourceId = "75ca6be9-1040-4797-b62d-74a41cae7655",
                DeviceName = "device_3",
                DeviceGroup = "group_b",
                Direction = "in",
                Power = new List<PowerListModel>()
                {
                    new PowerListModel()
                    {
                        Min = 31.64977673439958,
                        Max = 54.480270481616174,
                        Avg = 43.06502360800788,
                        Timestamp = 1626300000
                    },
                    new PowerListModel()
                    {
                        Min = 43.90603252096313,
                        Max = 78.06630554765299,
                        Avg = 60.98616903430806,
                        Timestamp = 1626300900
                    },
                }
            },
        };

        public List<MeasurementModel> GetData()
        {
            return _data;
        }
    }
}
