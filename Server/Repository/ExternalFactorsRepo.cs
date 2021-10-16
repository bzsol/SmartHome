using Common.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server.Repository
{
    public class ExternalFactorsRepo
    {
        // This is the file where we save the data about the temperature
        private const string datafile = "extfact.json";

        public static IEnumerable<ExternalFactors> GetExternalFactors() {
            if (File.Exists(datafile) && new FileInfo(datafile).Length > 0)
            {
                // Existing JSON file -> Read all data from that
                return JsonSerializer.Deserialize<IEnumerable<ExternalFactors>>(File.ReadAllText(datafile));
            }
            else
            {
                // New list
                return new List<ExternalFactors>();
            }
        }

        public static void SaveExternalFactors(IEnumerable<ExternalFactors> temp)
        {
            File.WriteAllText(datafile, JsonSerializer.Serialize(temp));
        }

    }
}