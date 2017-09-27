using demoPoC.Models;
using demoPoC.RestClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoPoC.Services
{
    public class ConsistService
    {
        public async Task<List<Consist>> GetConsistAsync(string uri)
        {
            RestClient<Consist> restClient = new RestClient<Consist>();
            var ConsistList = await restClient.GetAsync(uri);
            return ConsistList;
        }

        public async Task PostConsistAsync(Consist Consist, string uri)
        {
            RestClient<Consist> restClient = new RestClient<Consist>();
            var teamsList = await restClient.PostAsync(Consist, uri);
        }

        public async Task PutConsistAsync(int id, Consist Consist, string uri)
        {
            RestClient<Consist> restClient = new RestClient<Consist>();
            var teamsList = await restClient.PutAsync(id, Consist, uri);
        }

        public async Task DeleteConsistAsync(int id, Consist Consist, string uri)
        {
            RestClient<Consist> restClient = new RestClient<Consist>();
            var teamsList = await restClient.DeleteAsync(id, Consist, uri);
        }
    }
}
