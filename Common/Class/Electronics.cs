using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Common.Model
{
    public class Electronics
    {
        public string EventName { get; set; }

        public DateTime EventTime { set; get; }

        public bool Continous { get; set; }

        public string Type { get; set; }

        public string ContinousToStringConverter
        {
            get => Continous == true ? "Végtelenített" : "Egyszeri";
        }

        public string EventTimeToStringConverter
        {
            get => Continous == true ? $"{EventTime.ToShortTimeString()} - Minden alkalommal" : $"{EventTime.ToShortTimeString()} - Egy alkalommal";
        }
    }
}
