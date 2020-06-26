using MyClientApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyClientApp.Services
{
    public class EmployeeServices
    {
        private string restUrl = "https://mybackendservicesapp.azurewebsites.net/";
        private HttpClient _client;
        public EmployeeServices()
        {
            _client = new HttpClient();
        }

        public async Task<List<Employee>> GetData()
        {
            var data = new List<Employee>();
            var uri = new Uri($"{restUrl}api/Employee");
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<List<Employee>>(content);
                }
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
