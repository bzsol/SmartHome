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
    }
}
