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
            double heatingvalue = 0;
            double climatevalue = 0;
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
                    inside = inside - (outside * 0.10 / 60);
                }
                else {
                    inside =  inside + (outside * 0.003 / 60);
                }
            }

            if(heating)
            {
                if (external.roomno1Climate.IsHeatingEnabled) heatingvalue += 0.01;
                if (external.bathClimate.IsHeatingEnabled) heatingvalue += 0.01;
                if (external.roomno2Climate.IsHeatingEnabled) heatingvalue += 0.01;
                if (external.roomno3Climate.IsHeatingEnabled) heatingvalue += 0.01;
                if (external.diningClimate.IsHeatingEnabled) heatingvalue += 0.02;
                if (external.kitchenClimate.IsHeatingEnabled) heatingvalue += 0.03;
                if (external.livingroomClimate.IsHeatingEnabled) heatingvalue += 0.03;
                if (external.entryClimate.IsHeatingEnabled) heatingvalue += 0.01;
                if (external.officeClimate.IsHeatingEnabled) heatingvalue += 0.01;

                if(!(external.Heating <= inside))
                {
                    inside = inside + (heatingvalue * 0.2) - (outside * 0.07 / 60);
                }
            }

            if (climate)
            {
                if (external.roomno1Climate.IsCoolingEnabled) climatevalue += 0.001;
                if (external.bathClimate.IsCoolingEnabled) climatevalue += 0.001;
                if (external.roomno2Climate.IsCoolingEnabled) climatevalue += 0.001;
                if (external.roomno3Climate.IsCoolingEnabled) climatevalue += 0.001;
                if (external.diningClimate.IsCoolingEnabled) climatevalue += 0.002;
                if (external.kitchenClimate.IsCoolingEnabled) climatevalue += 0.003;
                if (external.livingroomClimate.IsCoolingEnabled) climatevalue += 0.003;
                if (external.entryClimate.IsCoolingEnabled) climatevalue += 0.001;
                if (external.officeClimate.IsCoolingEnabled) climatevalue += 0.001;

                if (!(external.Cooling >= inside))
                {
                    //
                    inside = inside - (climatevalue * 0.2) - (outside * 0.10 / 60);
                }
            }
            return inside;
        }
    }
}
