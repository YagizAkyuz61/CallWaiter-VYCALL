using CallConseole.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CallConseole.Service
{
    class ApiService
    {
        public static async Task<bool> StationChanged(int id, int stationId)
        {
            var httpClient = new HttpClient();
            var masa = new MasaClass()
            {
                Id = id,
                StationID = stationId
            };
            var json = JsonConvert.SerializeObject(masa);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("https://localhost:44302/api/Station/" + id, content);
            return response.IsSuccessStatusCode;
        }
    }
}
