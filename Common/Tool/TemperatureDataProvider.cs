using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tool
{
    public  class TemperatureDataProvider
    {
        public float CurrentTemperature { get; set; }

        private DateTime DateTime { get; set; } = DateTime.Now;

        public TemperatureDataProvider(int hour)
        {
            this.hour = hour;
        }

        private int hour { get; set; }

        private float GetRandomTempData(int minValue, int maxValue, bool first = true)
        {
            if (first)
            {
                minValue += DeterminateWeek(DateTime.Day) + DeterminateDayTime(hour);
                maxValue += DeterminateWeek(DateTime.Day) + DeterminateDayTime(hour);
            }

            Random rand = new();
            return rand.Next(minValue, maxValue) / (float)100;
        }

        public void DeterminateCurrentTemperature()
        {
            int month = DateTime.Month;

            if (month == 1)
            {
                CurrentTemperature = GetRandomTempData(-300, 900);
            }
            else if (month == 2)
            {
                CurrentTemperature = GetRandomTempData(120, 1200);
            }
            else if (month == 3)
            {
                CurrentTemperature = GetRandomTempData(350, 1470);
            }
            else if (month == 4)
            {
                CurrentTemperature = GetRandomTempData(500, 1900);
            }
            else if (month == 5)
            {
                CurrentTemperature = GetRandomTempData(800, 2000);
            }
            else if (month == 6)
            {
                CurrentTemperature = GetRandomTempData(1400, 2700);
            }
            else if (month == 7)
            {
                CurrentTemperature = GetRandomTempData(1600, 2800);
            }
            else if (month == 8)
            {
                CurrentTemperature = GetRandomTempData(1800, 3000);
            }
            else if (month == 9)
            {
                CurrentTemperature = GetRandomTempData(1500, 2400);
            }
            else if (month == 10)
            {
                CurrentTemperature = GetRandomTempData(800, 2000);
            }
            else if (month == 11)
            {
                CurrentTemperature = GetRandomTempData(0, 1200);
            }
            else
            {
                CurrentTemperature = GetRandomTempData(-200, 900);
            }

            CurrentTemperature = (float)Math.Round(CurrentTemperature, 2);
        }

        public int DeterminateWeek(int days)
        {
            if (days < 8)
            {
                return 200;
            }
            else if (days < 16)
            {
                return 150;
            }
            else if (days < 23)
            {
                return 100;
            }
            else
            {
                return 50;
            }
        }

        public int DeterminateDayTime(int timeInHours)
        {
            if (timeInHours < 4)
            {
                return -800;
            }
            else if (timeInHours < 7)
            {
                return -400;
            }
            else if (timeInHours < 10)
            {
                return 0;
            }
            else if (timeInHours < 14)
            {
                return 150;
            }
            else if (timeInHours < 17)
            {
                return 0;
            }
            else if (timeInHours < 20)
            {
                return -150;
            }
            else if (timeInHours < 22)
            {
                return -300;
            }
            else
            {
                return -600;
            }
        }

        public void ModifyTemperature()
        {
            DateTime = DateTime.Now;
            if (DateTime.Hour < 4)
            {
                CurrentTemperature += GetRandomTempData(-20, 20, false);
            }
            else if (DateTime.Hour < 7)
            {
                CurrentTemperature += GetRandomTempData(-10, 20, false);
            }
            else if (DateTime.Hour < 10)
            {
                CurrentTemperature += GetRandomTempData(-10, 25, false);
            }
            else if (DateTime.Hour < 14)
            {
                CurrentTemperature += GetRandomTempData(10, 30, false);
            }
            else if (DateTime.Hour < 20)
            {
                CurrentTemperature += GetRandomTempData(-25, -10, false);
            }
            else if (DateTime.Hour < 22)
            {
                CurrentTemperature += GetRandomTempData(-25, -20, false);
            }
            else
            {
                CurrentTemperature += GetRandomTempData(-30, -20, false);
            }

            CurrentTemperature = (float)Math.Round(CurrentTemperature, 2);
        }
    }
}
