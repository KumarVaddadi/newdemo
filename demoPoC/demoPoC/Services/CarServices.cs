using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demoPoC.Models;
using demoPoC.RestClients;

namespace demoPoC.Services
{
    public class CarServices
    {
        public async Task<List<Car>> GetCarsAsync(string uri)
        {
            RestClient<Car> restClient = new RestClient<Car>();
            var CarsList = await restClient.GetAsync(uri);
            return CarsList;
        }

        public async Task PostCarsAsync(Car Car, string uri)
        {
            RestClient<Car> restClient = new RestClient<Car>();
            var teamsList = await restClient.PostAsync(Car, uri);
        }

        public async Task PutCarsAsync(int id, Car Car, string uri)
        {
            RestClient<Car> restClient = new RestClient<Car>();
            var teamsList = await restClient.PutAsync(id, Car, uri);
        }

        public async Task DeleteCarsAsync(int id, Car Car, string uri)
        {
            RestClient<Car> restClient = new RestClient<Car>();
            var teamsList = await restClient.DeleteAsync(id, Car, uri);
        }
    }
}
