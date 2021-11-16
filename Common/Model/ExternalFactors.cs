using Common.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{



    public class ExternalFactors
    {
        [Key]
        public long ID { get; set; }

        // Time and Forecast

        public DateTime Time { get; set; }

        public enum Weather { cloudy, snowy, windy, sunshine, hot, rainy, stormy };

        public Weather Forecast { get; set; }

        // Szórakoztató eszközök

        public List<Electronics> TV { get; set; }

        public List<Electronics> Radio { get; set; }

        // Levegő
        public double Temp { get; set; }

        public double Humidity { get; set; }

        public double CO2 { get; set; }

        public bool isCO2sample { get; set; }

        public bool isHumiditysample { get; set; }

        public bool isDehumidification { get; set; }

        public bool isVentilation { get; set; }
        // AC

        public double Heating { get; set; }

        public double Cooling { get; set; }

        public enum Modes { swing, sleep, silent, turbo };

        // Helységek
        public Climate entryClimate { get; set; }
        public Climate livingroomClimate { get; set; }
        public Climate kitchenClimate { get; set; }
        public Climate officeClimate { get; set; }
        public Climate bathClimate { get; set; }
        public Climate terraceClimate { get; set; }
        public Climate roomno1Climate { get; set; }
        public Climate roomno2Climate { get; set; }
        public Climate roomno3Climate { get; set; }


        // Kültér Beltér

        public enum LightColor {warm,cold}

        public List<Lights> entryLights { get; set; }
        public List<Lights> livingroomLights { get; set; }
        public List<Lights> kitchenLights { get; set; }
        public List<Lights> officeLights { get; set; }
        public List<Lights> bathLights { get; set; }
        public List<Lights> terraceLights { get; set; }
        public List<Lights> roomno1Lights { get; set; }
        public List<Lights> roomno2Lights { get; set; }
        public List<Lights> roomno3Lights { get; set; }

        public List<Lights> GatewayLights { get; set; }
        public List<Lights> GardenLights { get; set; }
        public List<Lights> GarageLights { get; set; }
        public List<Lights> GateEntranceLights { get; set; }

        // Öntözés

        public List<Irrigative> Garden { get; set; }
        public List<Irrigative> FrontGarden { get; set; }

    }
}
