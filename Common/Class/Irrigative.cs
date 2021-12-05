using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Class
{
    public class Irrigative
    {
        public string Place { get; set; }

        public int State { get; set; }

        public int timespan { get; set; }
        
        public int TimeLeft { get; set; }

        public int strength { get; set; }

        public DateTime Time { get; set; }

        public int Temp { get; set; }

        public int Repeat { get; set; }

        public int RepeatTimeLeft { get; set; }

        public bool IsRepeated { get; set; }

        public bool IsTimeSetting { get; set; }

        public bool IsTempSetting { get; set; }

        // Factors
        public bool isSunny { get; set; }
        public bool isCloudy { get; set; }
        public bool isRain { get; set; }
        public bool isStorm { get; set; }
        public bool isSnow { get; set; }
        public bool isthunderstorm{ get; set;}
    }
}
