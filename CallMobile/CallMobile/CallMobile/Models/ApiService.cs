using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CallMobile.Models
{
    public class ApiService
    {
        public static async Task<List<MasaClass>> GetMasa()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://callapi.conveyor.cloud/api/masa");
            return JsonConvert.DeserializeObject<List<MasaClass>>(response);
        }

        public static async Task<bool> PutStation(int id, int stationId)
        {
            var userModel = new MasaClass()
            {
                Id = id,
                StationID = stationId
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(userModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("https://callapi.conveyor.cloud/api/station/" + id, content);
            return response.IsSuccessStatusCode;
        }
    }
}
