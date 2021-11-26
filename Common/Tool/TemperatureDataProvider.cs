using Common.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tool
{
    public static class TemperatureDataProvider
    {
        private const string server = "http://localhost:5000/api/extfacts";

        public static IEnumerable<ExternalFactors> Get()
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
                    var data = JsonConvert.DeserializeObject<IEnumerable<ExternalFactors>>(httpdata);
                    return data;
                }

            }
        }
        public static double GenerateTemp(int t) {
            // Kilengés * Sin(hossz*(t-eltolás X)) + y eltolás
            return 9 * Math.Sin(0.3 * (t - 7)) + 13;
        }
        public static double CalculateInsideTemp(double inside,double outside,int heating,bool climate) {
            // Ház térfogata
            var external = ((List<ExternalFactors>)Get()).FirstOrDefault(x => x.ID == 1);
            double heating_value = 0.0;
            if (climate)
            {
                return 0;
            }
            else {
                if (heating <= 0)
                {
                    if (outside > inside)
                    {
                        return inside + (outside * 0.01);
                    }
                    else
                    {
                        return inside - (outside * 0.07);
                    }
                }
                else
                {
                    if (heating <= inside)
                    {
                        return inside;
                    }
                    else
                    {
                        if (external.livingroomClimate.isHeatingEnabled) heating_value += 0.08;
                        if (external.officeClimate.isHeatingEnabled) heating_value += 0.01;
                        return inside + (heating_value * 0.4);
                    }
                }
            }
        }
    }
}
