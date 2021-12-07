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

        public static string GenerateForecast(string forecast) {
            var changeWeather = new Dictionary<string, double>();

            switch (forecast) {

                case "Sunny": {
                        changeWeather["Sunny"] = 32.2689011097057;
                        changeWeather["Cloudy"] = 35.6067750271923;
                        changeWeather["Thunderstorm"] = 3.62318137795412;
                        changeWeather["Rain"] = 23.8828193232803;
                        changeWeather["Storm"] = 5.36672179833806;
                        break;
                    }
                case "Cloudy":
                    {
                        changeWeather["Sunny"] = 26.2649273165632;
                        changeWeather["Cloudy"] = 35.1475234892176;
                        changeWeather["Thunderstorm"] = 9.63572049283275;
                        changeWeather["Rain"] = 16.1077075290676;
                        changeWeather["Storm"] = 13.3616951049127;
                        break;
                    }
                case "Rain":
                    {
                        changeWeather["Sunny"] = 24.3428237823409;
                        changeWeather["Cloudy"] = 33.402990672997;
                        changeWeather["Thunderstorm"] = 5.04112632534668;
                        changeWeather["Rain"] = 27.339336479267;
                        changeWeather["Storm"] = 10.2632878898938;
                        break;
                    }
                case "Storm":
                    {
                        changeWeather["Sunny"] = 8.03927530629527;
                        changeWeather["Cloudy"] = 13.7489354722255;
                        changeWeather["Thunderstorm"] = 16.5529497854222;
                        changeWeather["Rain"] = 35.8883976019561;
                        changeWeather["Storm"] = 26.6692349277299;
                        break;
                    }
                case "Thunderstorm":
                    {
                        changeWeather["Sunny"] = 7.98652567108466;
                        changeWeather["Cloudy"] = 26.124501006871;
                        changeWeather["Thunderstorm"] = 7.98652567108466;
                        changeWeather["Rain"] = 30.8721384397728;
                        changeWeather["Storm"] = 16.2225589975816;
                        break;
                    }
                default:  {
                        changeWeather["Sunny"] = 25;
                        changeWeather["Cloudy"] = 25;
                        changeWeather["Thunderstorm"] = 25;
                        changeWeather["Rain"] = 25;
                        changeWeather["Storm"] = 25;
                        break;
                    }
                   
            }
            List<KeyValuePair<string, double>> probs = changeWeather.ToList();
            Random random = new Random();
            double cumulative = 0.0;
            string ans = string.Empty;
            var calc = random.NextDouble()*100;
            for (int i = 0; i < probs.Count; i++)
            {
                cumulative += probs[i].Value;
                if (calc < cumulative)
                {
                    ans = probs[i].Key;
                    break;
                }
            }
            switch (ans)
            {
                case "Sunny":
                    {
                        return "Tiszta";
                    }
                case "Cloudy":
                    {
                        return "Felhős";
                    }
                case "Thunderstorm":
                    {
                        return "Vihar";
                    }
                case "Rain":
                    {
                        return "Eső";
                    }
                case "Storm":
                    {
                        return "Zápor";
                    }
                default:
                    {
                        return "nem meghatározható";
                    }
            }
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
