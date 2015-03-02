using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Clients;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Company;
using XOMNI.SDK.Public.Extensions;

namespace XOMNI.SDK.Public.Clients.Company
{
    public class DeviceClient : BaseClient
    {
        public DeviceClient(HttpClient httpClient)
            : base(httpClient)
        {

        }

        public async Task DeleteAsync(string deviceId)
        {
            Validator.For(deviceId, "deviceId").IsNotNullOrEmpty();
            string path = string.Format("/company/devices/{0}", deviceId);
            await Client.DeleteAsync(path).ConfigureAwait(false);
        }

        public async Task<ApiResponse<List<Device>>> GetAsync(double searchDistance, Location gpsLocation, int? deviceTypeId = null, string metadataKey = null, string metadataValue = null, bool includeMetadata = false)
        {
            Validator.For(searchDistance, "searchDistance").InRange(0, 1);
            Validator.For(gpsLocation, "gpsLocation").IsNotNull();
            Validator.For(gpsLocation.Latitude, "Latitude").InRange(-90, 90);
            Validator.For(gpsLocation.Longitude, "Longitude").InRange(-180, 180);

            string path = string.Format("/company/stores/{0}/Devices?searchDistance={1}&", gpsLocation.GetFormattedLocation(), searchDistance);
            if (deviceTypeId != null)
            {
                Validator.For(deviceTypeId, "deviceTypeId").IsGreaterThanOrEqual(1);
                path += string.Format("deviceTypeId={0}&", deviceTypeId);
            }

            if (!string.IsNullOrEmpty(metadataKey) && !string.IsNullOrEmpty(metadataValue))
            {
                path += string.Format("metadataKey={0}&metadataValue={1}&", metadataKey, metadataValue);
            }

            else if (!string.IsNullOrEmpty(metadataKey) || !string.IsNullOrEmpty(metadataValue))
            {
                Validator.For(metadataKey, "metadataKey").IsNotNullOrEmpty();
                Validator.For(metadataValue, "metadataValue").IsNotNullOrEmpty();
            }

            path += string.Format("includeMetadata={0}", includeMetadata);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<List<Device>>>().ConfigureAwait(false);
            }
        }

        public async Task<ApiResponse<List<Device>>> GetAsync(int? deviceTypeId = null, string metadataKey = null, string metadataValue = null, bool includeMetadata = false)
        {
            string path = "/company/stores/devices?";

            if (deviceTypeId != null)
            {
                Validator.For(deviceTypeId, "deviceTypeId").IsGreaterThanOrEqual(1);
                path += string.Format("deviceTypeId={0}&", deviceTypeId);
            }

            if (!string.IsNullOrEmpty(metadataKey) && !string.IsNullOrEmpty(metadataValue))
            {
                path += string.Format("metadataKey={0}&metadataValue={1}&", metadataKey, metadataValue);
            }
            else if (!string.IsNullOrEmpty(metadataKey) || !string.IsNullOrEmpty(metadataValue))
            {
                Validator.For(metadataKey, "metadataKey").IsNotNullOrEmpty();
                Validator.For(metadataValue, "metadataValue").IsNotNullOrEmpty();
            }

            path += string.Format("includeMetadata={0}", includeMetadata);

            using (var response = await Client.GetAsync(path).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<List<Device>>>().ConfigureAwait(false);
            }
        }

        public async Task<ApiResponse<Device>> PatchAsync(string deviceId, Device device)
        {
            Validator.For(deviceId, "deviceId").IsNotNullOrEmpty();
            Validator.For(device, "device").IsNotNull();
            string path = string.Format("/company/devices/{0}", deviceId);

            using (var response = await Client.PatchAsJsonAsync(path, device).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<Device>>().ConfigureAwait(false);
            }
        }

        public async Task<ApiResponse<Device>> PostAsync(string deviceId, string description, Device device)
        {
            Validator.For(deviceId, "deviceId").IsNotNullOrEmpty();
            Validator.For(description, "description").IsNotNullOrEmpty();
            Validator.For(device, "device").IsNotNull();
            string path = "/company/devices";

            using (var response = await Client.PostAsJsonAsync(path, device).ConfigureAwait(false))
            {
                return await response.Content.ReadAsAsync<ApiResponse<Device>>().ConfigureAwait(false);
            }
        }
    }
}