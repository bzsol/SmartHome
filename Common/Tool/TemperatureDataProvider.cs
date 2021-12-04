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
        public static double GenerateTemp(int t)
        {
            // Kilengés * Sin(hossz*(t-eltolás X)) + y eltolás
            //return 9 * Math.Sin(0.3 * (t - 7)) + 13;
            return (900 * Math.Sin(0.0045 * (t - 500)) + 1300) / 100;
        }

        public static int GenerateLight(int t)
        {
            var x = ((900 * Math.Sin(0.0045 * (t - 500)) + 700));
            return (x <= 0) ? 0 : (int)x;
        }

        public static double CO2(double co2, ExternalFactors external)
        {
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


        public static double CalculateInsideTemp(double inside, double outside, ExternalFactors external)
        {
            double cooling_factor = 0.0;
            double heating_factor = 0.0;

            if (external.entryClimate.IsCoolingEnabled) { cooling_factor += 0.1; }
            if (external.kitchenClimate.IsCoolingEnabled) { cooling_factor += 0.15; }
            if (external.livingroomClimate.IsCoolingEnabled) { cooling_factor += 0.15; }
            if (external.officeClimate.IsCoolingEnabled)
            {
                cooling_factor += 0.1;
            }
            if (external.roomno1Climate.IsCoolingEnabled)
            {
                cooling_factor += 0.1;
            }
            if (external.roomno2Climate.IsCoolingEnabled)
            {
                cooling_factor += 0.1;
            }
            if (external.roomno3Climate.IsCoolingEnabled) { cooling_factor += 0.1; }
            if (external.diningClimate.IsCoolingEnabled) { cooling_factor += 0.1; }
            if (external.bathClimate.IsCoolingEnabled) { cooling_factor += 0.1; }
            if (external.entryClimate.IsHeatingEnabled)
            {
                heating_factor += 0.1;
            }
            if (external.kitchenClimate.IsHeatingEnabled) { heating_factor += 0.15; }
            if (external.livingroomClimate.IsHeatingEnabled) { heating_factor += 0.15; }
            if (external.officeClimate.IsHeatingEnabled) { heating_factor += 0.1; }
            if (external.roomno1Climate.IsHeatingEnabled)
            {
                heating_factor += 0.1;
            }
            if (external.roomno2Climate.IsHeatingEnabled) { heating_factor += 0.1; }
            if (external.roomno3Climate.IsHeatingEnabled) { heating_factor += 0.1; }
            if (external.diningClimate.IsHeatingEnabled) { heating_factor += 0.1; }
            if (external.bathClimate.IsHeatingEnabled)
            {
                heating_factor += 0.1;
            }
            // Hűtés bekapcsolt állapota
            if (external.entryClimate.IsCoolingEnabled || external.kitchenClimate.IsCoolingEnabled || external.livingroomClimate.IsCoolingEnabled || external.officeClimate.IsCoolingEnabled || external.roomno1Climate.IsCoolingEnabled || external.roomno2Climate.IsCoolingEnabled || external.roomno3Climate.IsCoolingEnabled || external.diningClimate.IsCoolingEnabled || external.bathClimate.IsCoolingEnabled)
            {
                if (external.Cooling * 1.10 < inside)
                {
                    switch (external.entryClimate.Level)
                    {
                        case 1: break;
                        case 2:
                            heating_factor += 0.0001;
                            break;
                        case 3:
                            heating_factor += 0.0002;
                            break;
                    }
                    switch (external.kitchenClimate.Level)
                    {
                        case 1: break;
                        case 2:
                            heating_factor += 0.0001;
                            break;
                        case 3:
                            heating_factor += 0.0002;
                            break;
                    }
                    switch (external.livingroomClimate.Level)
                    {
                        case 1: break;
                        case 2:
                            heating_factor += 0.0001;
                            break;
                        case 3:
                            heating_factor += 0.0002;
                            break;
                    }
                    switch (external.officeClimate.Level)
                    {
                        case 1: break;
                        case 2:
                            heating_factor += 0.0001;
                            break;
                        case 3:
                            heating_factor += 0.0002;
                            break;
                    }
                    switch (external.roomno1Climate.Level)
                    {
                        case 1: break;
                        case 2:
                            heating_factor += 0.0001;
                            break;
                        case 3:
                            heating_factor += 0.0002;
                            break;
                    }
                    switch (external.roomno2Climate.Level)
                    {
                        case 1: break;
                        case 2:
                            heating_factor += 0.0001;
                            break;
                        case 3:
                            heating_factor += 0.0002;
                            break;
                    }
                    switch (external.roomno3Climate.Level)
                    {
                        case 1: break;
                        case 2:
                            heating_factor += 0.0001;
                            break;
                        case 3:
                            heating_factor += 0.0002;
                            break;
                    }
                    switch (external.diningClimate.Level)
                    {
                        case 1: break;
                        case 2:
                            heating_factor += 0.0001;
                            break;
                        case 3:
                            heating_factor += 0.0002;
                            break;
                    }
                    switch (external.bathClimate.Level)
                    {
                        case 1: break;
                        case 2:
                            heating_factor += 0.0001;
                            break;
                        case 3:
                            heating_factor += 0.0002;
                            break;
                    }
                    if (!(external.Cooling >= inside))
                    {
                        inside = inside - (cooling_factor * 0.05);
                    }
                }
            }


            if (external.entryClimate.IsHeatingEnabled || external.kitchenClimate.IsHeatingEnabled || external.livingroomClimate.IsHeatingEnabled || external.officeClimate.IsHeatingEnabled || external.roomno1Climate.IsHeatingEnabled || external.roomno2Climate.IsHeatingEnabled || external.roomno3Climate.IsHeatingEnabled || external.diningClimate.IsHeatingEnabled || external.bathClimate.IsHeatingEnabled)
            {
                if (external.Heating > inside && heating_factor >= 0.3)
                {
                    inside = inside + (heating_factor * 0.05);
                }
                else if (heating_factor < 0.3)
                {
                    inside = inside + (heating_factor * 0.02);
                }

            }

            if (outside < inside)
            {
                return inside - (outside * 0.002);
            }
            else
            {
                return inside + (outside * 0.001);
            }
        }
    }
}
