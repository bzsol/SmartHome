using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Tool
{
    public static class ToolKit
    {
        public static string SecToMilitaryTime(int seconds)
        {
            return TimeSpan.FromSeconds(seconds).ToString(@"h\:mm\:ss");
        }

        public static bool IsValidTime(string SelectedTime)
        {
            if (SelectedTime == null)
            {
                return false;
            }

            return Regex.IsMatch(SelectedTime, "([0-9]|[1][0-9]|[2][0-3]):[0-5][0-9]");
        }
    }
}
