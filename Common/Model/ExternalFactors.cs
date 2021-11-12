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

        public DateTime Time { get; set; }

        public enum Weather { cloudy, snowy, windy, sunshine, hot, rainy, stormy };

        public Weather Forecast { get; set; }

        // Szórakoztató eszközök

        public string EventName { get; set; }

        public DateTime EventTime { set; get; }

        public bool Continous { get; set; }

        public enum ElectronicsType { TV, Radio };

        public ElectronicsType ElectronicType { get; set; }

        // Redőny
        public int shutter { get; set; }

        public int gradiation { get; set; }

        // Világítás

        public double Brigtness { get; set; }

        public enum LightingColor { cold, warm };

        public LightingColor LightColor { get; set; }

        // Öntözőrendszer

        public int IriggationStrenght { get; set; }

        public DateTime IrrigationStart { get; set; }

        public DateTime IrrigationEnd { get; set; }


        // Levegő
        public double Temp { get; set; }

        public double Humidity { get; set; }

        public double CO2 { get; set; }

        public double CO { get; set; }

        // AC

        public double Heating { get; set; }

        public double Cooling { get; set; }

        public int CoolingDegree { get; set; }

        public enum Modes { swing, sleep, silent, turbo };

        public Modes AirQuality { get; set; }

        public int Level { get; set; }


        // Helységek
        public bool entry { get; set; }
        public bool livingroom { get; set; }
        public bool kithcen { get; set; }
        public bool office { get; set; }
        public bool bath { get; set; }
        public bool terrace { get; set; }
        public bool roomno1 { get; set; }
        public bool roomno2 { get; set; }
        public bool roomno3 { get; set; }

        // Helység módok
        public Modes entryModes { get; set; }
        public Modes livingroomModes { get; set; }
        public Modes kithcenModes { get; set; }
        public Modes officeModes { get; set; }
        public Modes bathModes { get; set; }
        public Modes terraceModes { get; set; }
        public Modes roomno1Modes { get; set; }
        public Modes roomno2Modes { get; set; }
        public Modes roomno3Modes { get; set; }


        // Helység fokozat
        public int entryLevel { get; set; }
        public int livingroomLevel { get; set; }
        public int kithcenLevel { get; set; }
        public int officeLevel { get; set; }
        public int bathLevel { get; set; }
        public int terraceLevel { get; set; }
        public int roomno1Level { get; set; }
        public int roomno2Level { get; set; }
        public int roomno3Level { get; set; }

        // Kültér Beltér
        public enum rooms {}
        bool isOutside { get; set; }

    }
}
