using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class ExternalFactors
    {
        public long ID { get; set; }

        // Time and Forecast

        public DateTime Time { get; set;}

        public enum Weather {cloudy,snowy,windy,sunshine,hot,rainy,stormy};

        public Weather Forecast { get; set;}


        // Air Quality and Temperature
        public double Temp { get; set; }

        public double Humidity { get; set; }
        
        public double CO2 { get; set; }

        public double CO { get; set; }

        // Lights
        public double Brigtness { get; set; }

        public enum LightingColor {cold,warm};

        public LightingColor LightColor { get; set; }


        // AC/Heating
        public double Heating { get; set; }

        public double Cooling { get; set; }

        public int CoolingDegree { get; set; }

        public enum Air { swing, sleep, silent, turbo };

        public Air AirQuality { get; set;}

        // Shutter
        public int Shutter { get; set;}

        public int Gradiation { get; set; }

        // Irrigation

        public TimeSpan IrrigationInterval { get; set; }

        public int IriggationStrenght { get; set; }

        public IList<DateTime> IrrigationTime { set; get; }

        // Electronics

        public IList<String> Event { get; set; }

        public IList<DateTime> EventTime { set; get; }

        public bool Continous { get; set;}

        public enum ElectronicsType {TV,Radio};

        public ElectronicsType ElectronicType { get; set; }
    }
}
