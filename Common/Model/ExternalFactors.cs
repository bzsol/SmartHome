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

        public Electronics TV { get; set; }

        public Electronics Radio { get; set; }

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

        public Lights entryLights { get; set; }
        public Lights livingroomLights { get; set; }
        public Lights kithcenLights { get; set; }
        public Lights officeLights { get; set; }
        public Lights bathLights { get; set; }
        public Lights terraceLights { get; set; }
        public Lights roomno1Lights { get; set; }
        public Lights roomno2Lights { get; set; }
        public Lights roomno3Lights { get; set; }

        // Öntözés

        public Irrigative Garden { get; set; }
        public Irrigative FrontGarden { get; set; }

    }
}
