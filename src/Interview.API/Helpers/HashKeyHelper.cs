using ABB.Interview.API.Measurements.Models;
using System.Security.Cryptography;
using System.Text;

namespace ABB.Interview.API.Helpers
{
    public static class HashKeyHelper
    {
        public static string GetHashKey(MeasurementModel measurement) 
        {
            string combinedValues = $"{measurement.ResourceId}{measurement.DeviceName}{measurement.DeviceGroup}{measurement.Direction}";
            return CreateHashKey(combinedValues);
        }

        private static string CreateHashKey(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
