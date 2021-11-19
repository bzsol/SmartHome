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
        public ExternalFactors(List<Electronics> tV, List<Electronics> radio, Climate entryClimate, Climate livingroomClimate, Climate kitchenClimate, Climate officeClimate, Climate bathClimate, Climate terraceClimate, Climate roomno1Climate, Climate roomno2Climate, Climate roomno3Climate, List<Lights> entryLights, List<Lights> livingroomLights, List<Lights> kitchenLights, List<Lights> officeLights, List<Lights> bathLights, List<Lights> terraceLights, List<Lights> roomno1Lights, List<Lights> roomno2Lights, List<Lights> roomno3Lights, List<Lights> gatewayLights, List<Lights> gardenLights, List<Lights> garageLights, List<Lights> gateEntranceLights, List<Irrigative> garden, List<Irrigative> frontGarden)
        {
            TV = tV;
            Radio = radio;
            this.entryClimate = entryClimate;
            this.livingroomClimate = livingroomClimate;
            this.kitchenClimate = kitchenClimate;
            this.officeClimate = officeClimate;
            this.bathClimate = bathClimate;
            this.terraceClimate = terraceClimate;
            this.roomno1Climate = roomno1Climate;
            this.roomno2Climate = roomno2Climate;
            this.roomno3Climate = roomno3Climate;
            this.entryLights = entryLights;
            this.livingroomLights = livingroomLights;
            this.kitchenLights = kitchenLights;
            this.officeLights = officeLights;
            this.bathLights = bathLights;
            this.terraceLights = terraceLights;
            this.roomno1Lights = roomno1Lights;
            this.roomno2Lights = roomno2Lights;
            this.roomno3Lights = roomno3Lights;
            this.gatewayLights = gatewayLights;
            this.gardenLights = gardenLights;
            this.garageLights = garageLights;
            this.gateEntranceLights = gateEntranceLights;
            this.garden = garden;
            this.frontGarden = frontGarden;
        }

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

        public Lights entryLights { get; set; }
        public Lights livingroomLights { get; set; }
        public Lights kitchenLights { get; set; }
        public Lights officeLights { get; set; }
        public Lights bathLights { get; set; }
        public Lights terraceLights { get; set; }
        public Lights roomno1Lights { get; set; }
        public Lights roomno2Lights { get; set; }
        public Lights roomno3Lights { get; set; }

        public Lights gatewayLights { get; set; }
        public Lights gardenLights { get; set; }
        public Lights garageLights { get; set; }
        public Lights gateEntranceLights { get; set; }

        // Öntözés

        public List<Irrigative> garden { get; set; }
        public List<Irrigative> frontGarden { get; set; }

        // Árnyékbox
        public Shading entryShading { get; set; }
        public Shading livingroomShading { get; set; }
        public Shading kitchenShading { get; set; }
        public Shading officeShading { get; set; }
        public Shading bathShading { get; set; }
        public Shading roomno1Shading { get; set; }
        public Shading roomno2Shading { get; set; }
        public Shading roomno3Shading { get; set; }

    }
}
