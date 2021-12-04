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
        public ExternalFactors(List<Electronics> electronicEvents, Climate entryClimate, Climate livingroomClimate, Climate kitchenClimate, Climate officeClimate, Climate bathClimate, Climate diningClimate, Climate roomno1Climate, Climate roomno2Climate, Climate roomno3Climate, Lights entryLights, Lights livingroomLights, Lights kitchenLights, Lights officeLights, Lights bathLights, Lights diningLights, Lights roomno1Lights, Lights roomno2Lights, Lights roomno3Lights, Lights gardenLights, Lights gardenLights2, Lights garageLights, Lights garageLights2, Lights gateEntranceLights, Lights gateEntranceLights2, Irrigative garden, Irrigative frontGarden, Shading livingroomShading, Shading kitchenShading, Shading officeShading, Shading bathRightWindowShading, Shading roomno1Shading, Shading roomno2Shading, Shading roomno3Shading,Shading livingroomPanoramaShading,Shading bathleftWindowShading,Shading diningShading)
        {
            ElectronicEvents = electronicEvents;
            this.entryClimate = entryClimate;
            this.livingroomClimate = livingroomClimate;
            this.kitchenClimate = kitchenClimate;
            this.officeClimate = officeClimate;
            this.bathClimate = bathClimate;
            this.diningClimate = diningClimate;
            this.roomno1Climate = roomno1Climate;
            this.roomno2Climate = roomno2Climate;
            this.roomno3Climate = roomno3Climate;
            this.entryLights = entryLights;
            this.entryLights.Place = "Entry";
            this.livingroomLights = livingroomLights;
            this.livingroomLights.Place = "Livingroom";
            this.kitchenLights = kitchenLights;
            this.kitchenLights.Place = "Kitchen";
            this.officeLights = officeLights;
            this.officeLights.Place = "Office";
            this.bathLights = bathLights;
            this.bathLights.Place = "Bath";
            this.diningLights = diningLights;
            this.diningLights.Place = "Dining";
            this.roomno1Lights = roomno1Lights;
            this.roomno1Lights.Place = "Room1";
            this.roomno2Lights = roomno2Lights;
            this.roomno2Lights.Place = "Room2";
            this.roomno3Lights = roomno3Lights;
            this.roomno3Lights.Place = "Room3";
            this.gardenLights = gardenLights;
            this.gardenLights.Place = "Garden";
            this.gardenLights2 = gardenLights2;
            this.gardenLights2.Place = "Garden2";
            this.garageLights = garageLights;
            this.garageLights.Place = "Garage";
            this.garageLights2 = garageLights2;
            this.garageLights2.Place = "Garage2";
            this.gateEntranceLights = gateEntranceLights;
            this.gateEntranceLights.Place = "Gate";
            this.gateEntranceLights2 = gateEntranceLights2;
            this.gateEntranceLights2.Place = "Gate2";
            this.garden = garden;
            this.garden.Place = "Garden";
            this.frontGarden = frontGarden;
            this.frontGarden.Place = "FrontGarden";
            this.livingroomShading = livingroomShading;
            this.livingroomShading.Place = "LivingBig";
            this.kitchenShading = kitchenShading;
            this.kitchenShading.Place = "Kitchen";
            this.officeShading = officeShading;
            this.officeShading.Place = "Office";
            this.bathRightWindowShading = bathRightWindowShading;
            this.bathRightWindowShading.Place = "BathRight";
            this.roomno1Shading = roomno1Shading;
            this.roomno1Shading.Place = "Room1";
            this.roomno2Shading = roomno2Shading;
            this.roomno2Shading.Place = "Room2";
            this.roomno3Shading = roomno3Shading;
            this.roomno3Shading.Place = "Room3";
            this.livingroomPanoramaShading = livingroomPanoramaShading;
            this.livingroomPanoramaShading.Place = "LivingPanorama";
            this.bathLeftWindowShading = bathleftWindowShading;
            this.bathLeftWindowShading.Place = "BathLeft";
            this.diningShading = diningShading;
            this.diningShading.Place = "Dining";
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

        public int Heating { get; set; }

        public int Cooling { get; set; }

        public enum Modes { NORMAL, SWING, TURBO, SILENT, SLEEP };

        // Helységek
        public Climate entryClimate { get; set; }
        public Climate livingroomClimate { get; set; }
        public Climate kitchenClimate { get; set; }
        public Climate officeClimate { get; set; }
        public Climate bathClimate { get; set; }
        public Climate diningClimate { get; set; }
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
        public Lights diningLights { get; set; }
        public Lights roomno1Lights { get; set; }
        public Lights roomno2Lights { get; set; }
        public Lights roomno3Lights { get; set; }
        public Lights gardenLights { get; set; }
        public Lights gardenLights2 { get; set; }
        public Lights garageLights { get; set; }
        public Lights garageLights2 { get; set; }
        public Lights gateEntranceLights { get; set; }
        public Lights gateEntranceLights2 { get; set; }

        // Öntözés

        public Irrigative garden { get; set; }
        public Irrigative frontGarden { get; set; }

        // Árnyékolás

        public enum ShadePreference { NONE, TIME, PHOTOSENSITIVTY }

        public Shading livingroomShading { get; set; }
        public Shading livingroomPanoramaShading { get; set; }
        public Shading bathLeftWindowShading { get; set; }
        public Shading kitchenShading { get; set; }
        public Shading officeShading { get; set; }
        public Shading bathRightWindowShading { get; set; }
        public Shading roomno1Shading { get; set; }
        public Shading roomno2Shading { get; set; }
        public Shading roomno3Shading { get; set; }
        public Shading diningShading { get; set; }

    }
}
