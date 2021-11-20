using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Class
{
    public class Irrigative
    {
        public int timespan { get; set; }

        public int strenght { get; set; }

        public DateTime dateTime { get; set; }

        public int Temp { get; set; }

        public int Repeat { get; set;}

        // Factors
        public bool isSunny { get; set; }
        public bool isCloudy { get; set; }
        public bool isRain { get; set; }
        public bool isStorm { get; set; }
        public bool isSnow { get; set; }
        public bool isthunderstorm{ get; set;}
    }
}
