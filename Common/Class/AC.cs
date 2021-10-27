using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Class
{
    public class AC
    {
        public double Heating { get; set; }

        public double Cooling { get; set; }

        public int CoolingDegree { get; set; }

        public enum modes { swing, sleep, silent, turbo };

        public modes AirQuality { get; set; }
    }
}
