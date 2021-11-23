using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tool
{
    public static class TemperatureDataProvider
    {
        public static double GenerateTemp(int t) {

            return 9 * Math.Sin(0.3 * (t - 6.5)) + 13;
        }
        

    }
}
