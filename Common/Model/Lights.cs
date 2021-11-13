using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.Model.ExternalFactors;

namespace Common.Model
{
    public class Lights
    {
        public bool isLightsEnabled { get; set; }

        public int strenght { get; set; }

        public LightColor color { get; set; }

        public bool motionDetection { get; set; }

        public int activeSpan { get; set; }
    }
}
