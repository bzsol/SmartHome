using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Class
{
    public class Light
    {
        public double Brigtness { get; set; }

        public enum LightingColor { cold, warm };

        public LightingColor LightColor { get; set; }
    }
}
