using Common.Class;
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


        // Air Quality and Temperature
        public Air air { get; set; }

        // Lights
        public Light light { get; set; }


        // AC/Heating
        public AC ac { get; set; }

        // Shutter
        public Shutter shutter { get; set; }

        // Irrigation

        public Irrigation irrigation { get; set; }

        // Electronics

        public Electronics electronics { get; set; }
    }
}
