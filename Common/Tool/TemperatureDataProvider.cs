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

        public static double GenerateLight(int t) {
            var x = ((900 * Math.Sin(0.0045 * (t - 500)) + 700));
            return (x <= 0) ? 0 : x;
        }

        public static double CO2(double co2,ExternalFactors external) {
            var co2factor = co2;
            if (external.roomno1Climate.IsHeatingEnabled) co2factor += 0.00000001;
            if (external.roomno2Climate.IsHeatingEnabled) co2factor += 0.00000001;
            if (external.roomno3Climate.IsHeatingEnabled) co2factor += 0.00000001;
            if (external.kitchenClimate.IsHeatingEnabled) co2factor += 0.0000000015;
            if (external.livingroomClimate.IsHeatingEnabled) co2factor += 0.000000015;
            if (external.officeClimate.IsHeatingEnabled) co2factor += 0.0000000000001;
            if (external.entryClimate.IsHeatingEnabled) co2factor += 0.00000000000001;
            if (external.diningClimate.IsHeatingEnabled) co2factor += 0.0000000000001;
            if (external.bathClimate.IsHeatingEnabled) co2factor += 0.000000000000001;
            
            return co2factor; 
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
                if (external.roomno1Climate.IsCoolingEnabled) {
                    if (external.roomno1Climate.Level == 1)
                    {
                        climatevalue += 0.01;
                    }
                    else if (external.roomno1Climate.Level == 2)
                    {
                        climatevalue += 0.02;
                    }
                    else if (external.roomno1Climate.Level == 3) {
                        climatevalue += 0.03;
                    }
                }
                if (external.bathClimate.IsCoolingEnabled)
                {
                    if (external.bathClimate.Level == 1)
                    {
                        climatevalue += 0.01;
                    }
                    else if (external.bathClimate.Level == 2)
                    {
                        climatevalue += 0.02;
                    }
                    else if (external.bathClimate.Level == 3)
                    {
                        climatevalue += 0.03;
                    }

                }
                if (external.roomno2Climate.IsCoolingEnabled) {
                    if (external.roomno2Climate.Level == 1)
                    {
                        climatevalue += 0.01;
                    }
                    else if (external.roomno2Climate.Level == 2)
                    {
                        climatevalue += 0.02;
                    }
                    else if (external.roomno2Climate.Level == 3)
                    {
                        climatevalue += 0.03;
                    }
                }
                if (external.roomno3Climate.IsCoolingEnabled) {
                    if (external.roomno3Climate.Level == 1)
                    {
                        climatevalue += 0.01;
                    }
                    else if (external.roomno3Climate.Level == 2)
                    {
                        climatevalue += 0.02;
                    }
                    else if (external.roomno3Climate.Level == 3)
                    {
                        climatevalue += 0.03;
                    }
                }
                if (external.diningClimate.IsCoolingEnabled) {
                    if (external.roomno1Climate.Level == 1)
                    {
                        climatevalue += 0.01;
                    }
                    else if (external.roomno1Climate.Level == 2)
                    {
                        climatevalue += 0.02;
                    }
                    else if (external.roomno1Climate.Level == 3)
                    {
                        climatevalue += 0.03;
                    }
                }
                if (external.kitchenClimate.IsCoolingEnabled) {
                    if (external.kitchenClimate.Level == 1)
                    {
                        climatevalue += 0.01;
                    }
                    else if (external.kitchenClimate.Level == 2)
                    {
                        climatevalue += 0.02;
                    }
                    else if (external.kitchenClimate.Level == 3)
                    {
                        climatevalue += 0.03;
                    }
                }
                if (external.livingroomClimate.IsCoolingEnabled) {
                    if (external.livingroomClimate.Level == 1)
                    {
                        climatevalue += 0.01;
                    }
                    else if (external.livingroomClimate.Level == 2)
                    {
                        climatevalue += 0.02;
                    }
                    else if (external.livingroomClimate.Level == 3)
                    {
                        climatevalue += 0.03;
                    }
                }
                if (external.entryClimate.IsCoolingEnabled) {
                    if (external.livingroomClimate.Level == 1)
                    {
                        climatevalue += 0.01;
                    }
                    else if (external.livingroomClimate.Level == 2)
                    {
                        climatevalue += 0.02;
                    }
                    else if (external.livingroomClimate.Level == 3)
                    {
                        climatevalue += 0.03;
                    }
                }
                if (external.officeClimate.IsCoolingEnabled) {
                    if (external.entryClimate.Level == 1)
                    {
                        climatevalue += 0.01;
                    }
                    else if (external.entryClimate.Level == 2)
                    {
                        climatevalue += 0.02;
                    }
                    else if (external.entryClimate.Level == 3)
                    {
                        climatevalue += 0.03;
                    }
                } 

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
