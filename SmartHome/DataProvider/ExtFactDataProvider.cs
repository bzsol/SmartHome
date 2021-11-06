using Common.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataProvider
{
    public class ExtFactDataProvider
    {
        private const string server = "http://localhost:5000/api/extfacts";

        public static IEnumerable<ExternalFactors> GetPatients()
        {

            using (var client = new HttpClient())
            {
                var respone = client.GetAsync(server).Result;

                if (!respone.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(respone.StatusCode.ToString());
                }
                else
                {
                    var httpdata = client.GetStringAsync(server).Result;
                    var patients = JsonConvert.DeserializeObject<IEnumerable<ExternalFactors>>(httpdata);
                    return patients;
                }

            }
        }

        public static void CreatePatient(ExternalFactors patient)
        {
            using (var client = new HttpClient())
            {
                var httpdata = JsonConvert.SerializeObject(patient);
                var httppacket = new StringContent(httpdata, Encoding.UTF8, "application/json");

                var response = client.PostAsync(server, httppacket).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void UpdatePatient(ExternalFactors patient)
        {
            using (var client = new HttpClient())
            {
                var httpdata = JsonConvert.SerializeObject(patient);
                var httppacket = new StringContent(httpdata, Encoding.UTF8, "application/json");

                var response = client.PutAsync(server, httppacket).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void DeletePatient(long id)
        {
            using (var client = new HttpClient())
            {
                var response = client.DeleteAsync(server + "/" + id).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
    }
}
