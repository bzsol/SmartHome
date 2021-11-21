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
        public ExternalFactors(List<Electronics> electronicEvents, Climate entryClimate, Climate livingroomClimate, Climate kitchenClimate, Climate officeClimate, Climate bathClimate, Climate terraceClimate, Climate roomno1Climate, Climate roomno2Climate, Climate roomno3Climate, Lights entryLights, Lights livingroomLights, Lights kitchenLights, Lights officeLights, Lights bathLights, Lights terraceLights, Lights roomno1Lights, Lights roomno2Lights, Lights roomno3Lights, Lights gatewayLights, Lights gardenLights, Lights garageLights, Lights gateEntranceLights, Irrigative garden, Irrigative frontGarden, Shading entryShading, Shading livingroomShading, Shading kitchenShading, Shading officeShading, Shading bathShading, Shading roomno1Shading, Shading roomno2Shading, Shading roomno3Shading,Shading livingroomPanorama,Shading bathleftWindow,Shading terraceShading)
        {
            ElectronicEvents = electronicEvents;
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
            this.entryShading = entryShading;
            this.livingroomShading = livingroomShading;
            this.kitchenShading = kitchenShading;
            this.officeShading = officeShading;
            this.bathShading = bathShading;
            this.roomno1Shading = roomno1Shading;
            this.roomno2Shading = roomno2Shading;
            this.roomno3Shading = roomno3Shading;
            this.livingroomPanorama = livingroomPanorama;
            this.bathleftWindow = bathleftWindow;
            this.terraceShading = terraceShading;
            
        }

        [Key]
        public long ID { get; set; }

        // Time and Forecast

        public DateTime Time { get; set; }

        public enum Weather { cloudy, snowy, windy, sunshine, hot, rainy, stormy };

        public Weather Forecast { get; set; }

        // Szórakoztató eszközök

        public List<Electronics> ElectronicEvents { get; set; }

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

        public Irrigative garden { get; set; }
        public Irrigative frontGarden { get; set; }

        // Árnyékbox
        public Shading entryShading { get; set; }
        public Shading livingroomShading { get; set; }
        public Shading livingroomPanorama { get; set; }
        public Shading bathleftWindow { get; set; }
        public Shading kitchenShading { get; set; }
        public Shading officeShading { get; set; }
        public Shading bathShading { get; set; }
        public Shading roomno1Shading { get; set; }
        public Shading roomno2Shading { get; set; }
        public Shading roomno3Shading { get; set; }
        public Shading terraceShading { get; set; }

    }
}
