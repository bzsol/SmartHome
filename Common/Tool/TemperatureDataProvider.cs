using Common.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tool
{
    public static class TemperatureDataProvider
    {   
        public static double GenerateTemp(int t) {
            // Kilengés * Sin(hossz*(t-eltolás X)) + y eltolás
            //return 9 * Math.Sin(0.3 * (t - 7)) + 13;
            return (900 * Math.Sin(0.0045 * (t - 500)) + 1300)/100;
        }
        public static double CalculateInsideTemp(double inside, double outside, ExternalFactors external) {
            bool heating;
            bool climate;
            if (external.roomno1Climate.IsHeatingEnabled || external.roomno2Climate.IsHeatingEnabled || external.roomno3Climate.IsHeatingEnabled || external.kitchenClimate.IsHeatingEnabled ||
                external.livingroomClimate.IsHeatingEnabled || external.officeClimate.IsHeatingEnabled || external.entryClimate.IsHeatingEnabled || external.diningClimate.IsHeatingEnabled ||
                external.bathClimate.IsHeatingEnabled)
            {
                heating = true;
                climate = false;
            }
            else if (external.roomno1Climate.IsCoolingEnabled || external.roomno2Climate.IsCoolingEnabled || external.roomno3Climate.IsCoolingEnabled || external.kitchenClimate.IsCoolingEnabled ||
                external.livingroomClimate.IsCoolingEnabled || external.officeClimate.IsCoolingEnabled || external.entryClimate.IsCoolingEnabled || external.diningClimate.IsCoolingEnabled ||
                external.bathClimate.IsCoolingEnabled)
            {
                climate = true;
                heating = false;

            }
            else
            {
                heating = false;
                climate = false;
            }

            if (heating == false && climate == false)
            {
                if (inside > outside)
                {
                    return (inside - ((outside * 0.07) / 60));
                }
                else {
                    return (inside + ((outside * 0.03) / 60));
                }
            }

            return 0;
        }
    }
}
