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
            // Kilengés * Sin(hossz*(t-eltolás X)) + y eltolás
            return 9 * Math.Sin(0.3 * (t - 7)) + 13;
        }
        public static double CalculateInsideTemp(double inside,double outside,int heating) {
            // Ház térfogata
            //var V = 108 * 2 + 72 * 3 + 45 * 3 + 36;
            if (heating <= 0)
            {
                if (outside > inside)
                {
                    return inside + (outside * 0.01);
                }
                else
                {
                    return inside - (outside * 0.07);
                }
            }
            else {
                if (heating <= inside)
                {
                    return inside;
                }
                else {
                    return inside + 0.5;
                }
            }
        }
        

    }
}
