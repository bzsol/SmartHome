using Common.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server.Repository
{
    public class TempRepo
    {
        // This is the file where we save the data about the temperature
        private const string datafile = "temperature.json";

        public static IEnumerable<Temperature> GetTemperatures() {
            if (File.Exists(datafile) && new FileInfo(datafile).Length > 0)
            {
                // Existing JSON file -> Read all data from that
                return JsonSerializer.Deserialize<IEnumerable<Temperature>>(File.ReadAllText(datafile));
            }
            else
            {
                // New list
                return new List<Temperature>();
            }
        }

        public static void SaveTemperature(IEnumerable<Temperature> temp)
        {
            File.WriteAllText(datafile, JsonSerializer.Serialize(temp));
        }

    }
}